using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Profile;
using E_PortfolioSystem.Web.ViewModels.Recommendation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize(Roles = "HR")]
    public class HRController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IRecommendationService recommendationService;
        private readonly IExperienceService experienceService;
        private readonly ISkillService skillService;
        private readonly IEducationService educationService;
        private readonly ICertificateService certificateService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HRController(IProfileService profileService, IRecommendationService recommendationService, IExperienceService experienceService, ISkillService skillService, IEducationService educationService, ICertificateService certificateService, IWebHostEnvironment webHostEnvironment)
        {
            this.profileService = profileService;
            this.recommendationService = recommendationService;
            this.experienceService = experienceService;
            this.skillService = skillService;
            this.educationService = educationService;
            this.certificateService = certificateService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> PublicProfiles(string searchTerm, string location, int page = 1)
        {
            const int pageSize = 9;
            var profiles = await profileService.GetAllPublicProfilesAsync(searchTerm, location, page, pageSize);
            var totalProfiles = await profileService.GetTotalPublicProfilesCountAsync(searchTerm, location);
            var totalPages = (int)Math.Ceiling(totalProfiles / (double)pageSize);

            var viewModel = new PublicProfilesViewModel
            {
                Profiles = profiles,
                SearchTerm = searchTerm,
                Location = location,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalProfiles = totalProfiles
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Resume(string userId)
        {
            var profile = await profileService.GetProfileByUserIdAsync(userId);
            if (profile == null || !profile.IsPublic)
            {
                TempData["ErrorMessage"] = "Профилът не е публичен или не съществува.";
                return RedirectToAction("PublicProfiles");
            }
            return RedirectToAction("Resume", "Profile", new { userId });
        }

        public async Task<IActionResult> DownloadCV(string userId)
        {
            var profile = await profileService.GetProfileByUserIdAsync(userId);
            if (profile == null || !profile.IsPublic)
            {
                TempData["ErrorMessage"] = "Профилът не е публичен или не съществува.";
                return RedirectToAction("PublicProfiles");
            }
            var experiences = await experienceService.GetAllByUserIdAsync(userId);
            var skills = await skillService.GetAllByUserIdAsync(userId);
            var education = await educationService.GetAllByUserIdAsync(userId);
            var certificates = await certificateService.GetAllByUserIdAsync(userId);
            var resume = new E_PortfolioSystem.Web.ViewModels.Profile.ResumeViewModel
            {
                Id = profile.Id,
                FullName = profile.FullName,
                Experiences = experiences,
                Skills = skills,
                Educations = education,
                Certificates = certificates
            };
            var generator = new ResumePdfGenerator(resume, profile, webHostEnvironment);
            var pdfBytes = generator.Generate();
            return File(pdfBytes, "application/pdf", "CVDocument.pdf");
        }

        public async Task<IActionResult> Recommendations(string userId)
        {
            var recommendations = await recommendationService.GetRecommendationsForUserAsync(userId);
            ViewBag.ToUserId = userId;
            return View(recommendations);
        }

        [HttpGet]
        public IActionResult AddRecommendation(string userId)
        {
            ViewBag.ToUserId = userId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecommendation(string toUserId, string text)
        {
            var fromUserId = User.GetId();
            await recommendationService.AddRecommendationAsync(fromUserId, toUserId, text);
            TempData["SuccessMessage"] = "Препоръката беше добавена успешно!";
            return RedirectToAction("Recommendations", new { userId = toUserId });
        }

        [HttpGet]
        public async Task<IActionResult> EditRecommendation(string id)
        {
            var recommendation = await recommendationService.GetRecommendationByIdAsync(id);
            if (recommendation == null)
            {
                TempData[ErrorMessage] = "Препоръката не е намерена.";
                return RedirectToAction("PublicProfiles");
            }

            var currentUserId = User.GetId();
            if (!await recommendationService.IsOwnerAsync(id, currentUserId))
            {
                TempData[ErrorMessage] = "Нямате права да редактирате тази препоръка.";
                return RedirectToAction("Recommendations", new { userId = recommendation.ToUserId });
            }

            var targetUserProfile = await profileService.GetProfileByUserIdAsync(recommendation.ToUserId);
            if (targetUserProfile != null)
            {
                recommendation.ToUserFullName = targetUserProfile.FullName;
            }

            return View(recommendation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRecommendation(string id, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                ModelState.AddModelError("Text", "Текстът на препоръката е задължителен.");
                return View(new RecommendationViewModel { Id = id, Text = text });
            }

            try
            {
                var currentUserId = User.GetId();
                if (!await recommendationService.IsOwnerAsync(id, currentUserId))
                {
                    TempData[ErrorMessage] = "Нямате права да редактирате тази препоръка.";
                    return RedirectToAction("PublicProfiles");
                }

                await recommendationService.UpdateRecommendationAsync(id, text);
                TempData[SuccessMessage] = "Препоръката е успешно редактирана.";
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка при редактирането на препоръката.";
            }

            var recommendation = await recommendationService.GetRecommendationByIdAsync(id);
            return RedirectToAction("Recommendations", new { userId = recommendation?.ToUserId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRecommendation(string id)
        {
            try
            {
                var currentUserId = User.GetId();
                if (!await recommendationService.IsOwnerAsync(id, currentUserId))
                {
                    TempData[ErrorMessage] = "Нямате права да изтриете тази препоръка.";
                    return RedirectToAction("PublicProfiles");
                }

                var recommendation = await recommendationService.GetRecommendationByIdAsync(id);
                await recommendationService.DeleteRecommendationAsync(id);
                TempData[SuccessMessage] = "Препоръката е успешно изтрита.";
                return RedirectToAction("Recommendations", new { userId = recommendation?.ToUserId });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка при изтриването на препоръката.";
                return RedirectToAction("PublicProfiles");
            }
        }
    }
}
namespace E_PortfolioSystem.Web.Controllers
{
    using E_PortfolioSystem.Services.Data.Interfaces;
    using E_PortfolioSystem.Web.Infrastructure.Extensions;
    using E_PortfolioSystem.Web.ViewModels.Profile;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static E_PortfolioSystem.Web.Infrastructure.Extensions.ClaimsPrincipalExtensions;
    using static E_PortfolioSystem.Common.NotificationMessagesConstants;

    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IExperienceService experienceService;
        private readonly ISkillService skillService;
        private readonly IEducationService educationService;
        private readonly ICertificateService certificateService;

        public ProfileController(
             IProfileService profileService,
             IExperienceService experienceService,
             ISkillService skillService,
             IEducationService educationService,
             ICertificateService certificateService)
        {
            this.profileService = profileService;
            this.experienceService = experienceService;
            this.skillService = skillService;
            this.educationService = educationService;
            this.certificateService = certificateService;
        }

        public async Task<IActionResult> Resume()
        {
            try
            {
                var id = this.User.GetId();

                var profile = await profileService.GetProfileByUserIdAsync(id);
                var experiences = await experienceService.GetAllByUserIdAsync(id);
                var skills = await skillService.GetAllByUserIdAsync(id);
                var education = await educationService.GetAllByUserIdAsync(id);
                var certificates = await certificateService.GetAllByUserIdAsync(id);
                if (profile == null)
                {
                    TempData[ErrorMessage] = "Възникна грешка при зареждането на резюмето.";
                    return RedirectToAction("Index", "Home");
                }

                var model = new ResumeViewModel
                {
                    Id = profile.Id,
                    FullName = profile.FullName,
                    Experiences = experiences,
                    Skills = skills,
                    Educations = education,
                    Certificates = certificates
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на резюмето.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCV()
        {
            try
            {
                var id = this.User.GetId();

                var profile = await profileService.GetProfileByUserIdAsync(id);
                var experiences = await experienceService.GetAllByUserIdAsync(id);
                var skills = await skillService.GetAllByUserIdAsync(id);
                var education = await educationService.GetAllByUserIdAsync(id);
                var certificates = await certificateService.GetAllByUserIdAsync(id);

                var resume = new ResumeViewModel
                {
                    Id = profile.Id,
                    FullName = profile.FullName,
                    Experiences = experiences,
                    Skills = skills,
                    Educations = education,
                    Certificates = certificates
                };

                if (resume == null)
                {
                    return NotFound();
                }

                var generator = new ResumePdfGenerator(resume, profile);
                var pdfBytes = generator.Generate();

                return File(pdfBytes, "application/pdf", "CVDocument.pdf");
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при генерирането на CV документа.";
                return RedirectToAction("Resume");
            }
        }
    }
}

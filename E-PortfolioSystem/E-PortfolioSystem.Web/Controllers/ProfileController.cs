namespace E_PortfolioSystem.Web.Controllers
{
    using E_PortfolioSystem.Services.Data.Interfaces;
    using E_PortfolioSystem.Web.Infrastructure.Extensions;
    using E_PortfolioSystem.Web.ViewModels.Profile;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static E_PortfolioSystem.Web.Infrastructure.Extensions.ClaimsPrincipalExtensions;
    using static E_PortfolioSystem.Common.NotificationMessagesConstants;
    using Microsoft.AspNetCore.Identity;
    using E_PortfolioSystem.Data.Models;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using System.IO;

    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IExperienceService experienceService;
        private readonly ISkillService skillService;
        private readonly IEducationService educationService;
        private readonly ICertificateService certificateService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProfileController(
             IProfileService profileService,
             IExperienceService experienceService,
             ISkillService skillService,
             IEducationService educationService,
             ICertificateService certificateService,
             UserManager<ApplicationUser> userManager,
             IWebHostEnvironment webHostEnvironment)
        {
            this.profileService = profileService;
            this.experienceService = experienceService;
            this.skillService = skillService;
            this.educationService = educationService;
            this.certificateService = certificateService;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Resume(string? userId = null)
        {
            try
            {
                var id = userId ?? this.User.GetId();

                var profile = await profileService.GetProfileByUserIdAsync(id);
                if (profile == null || (!profile.IsPublic && userId != null))
                {
                    TempData[ErrorMessage] = "Профилът не е публичен или не съществува.";
                    return RedirectToAction("Index", "Home");
                }

                var experiences = await experienceService.GetAllByUserIdAsync(id);
                var skills = await skillService.GetAllByUserIdAsync(id);
                var education = await educationService.GetAllByUserIdAsync(id);
                var certificates = await certificateService.GetAllByUserIdAsync(id);

                var model = new ResumeViewModel
                {
                    Id = profile.Id,
                    UserId = id,
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

                if (profile == null)
                {
                    return NotFound();
                }

                var resume = new ResumeViewModel
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
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при генерирането на CV документа.";
                return RedirectToAction("Resume");
            }
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.GetId();

                if (!await profileService.ExistsByUserIdAsync(Guid.Parse(userId)))
                {
                    var user = await userManager.FindByIdAsync(userId);
                    await profileService.CreateProfileAsync(
                        Guid.Parse(userId),
                        $"{user.FirstName} {user.LastName}");
                }

                var profile = await profileService.GetProfileByUserIdAsync(userId);

                if (profile == null)
                {
                    TempData[ErrorMessage] = "Възникна грешка при зареждането на профила.";
                    return RedirectToAction("Index", "Home");
                }

                return View(profile);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на профила.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            try
            {
                var userId = User.GetId();
                var profile = await profileService.GetProfileByUserIdAsync(userId);

                if (profile == null)
                {
                    TempData[ErrorMessage] = "Възникна грешка при зареждането на профила.";
                    return RedirectToAction("Index", "Home");
                }

                return View(profile);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на профила.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileViewModel model, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.GetId();
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var names = model.FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            user.FirstName = names.Length > 0 ? names[0] : string.Empty;
            user.LastName = names.Length > 1 ? names[^1] : string.Empty;
            await userManager.UpdateAsync(user);

            // Обработка на новата снимка
            if (imageFile != null && imageFile.Length > 0)
            {
                // Проверка за валиден тип файл
                var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif" };
                if (!allowedTypes.Contains(imageFile.ContentType.ToLower()))
                {
                    ModelState.AddModelError("imageFile", "Моля, качете валиден файл (JPEG, PNG или GIF).");
                    return View(model);
                }

                // Проверка за размер на файла (макс. 5MB)
                if (imageFile.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("imageFile", "Размерът на файла не може да надвишава 5MB.");
                    return View(model);
                }

                var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads", "profile-images");
                Directory.CreateDirectory(uploadsFolder);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                model.ImageUrl = $"/uploads/profile-images/{fileName}";
            }
            else if (string.IsNullOrEmpty(model.ImageUrl))
            {
                model.ImageUrl = "/assets/profile.png";
            }

            await profileService.UpdateProfileAsync(
                Guid.Parse(userId),
                model.FullName,
                model.Phone,
                model.Bio,
                model.Location,
                model.ImageUrl,
                model.IsPublic);

            TempData[SuccessMessage] = "Профилът е успешно обновен.";
            return RedirectToAction(nameof(Index));
        }
    }
}
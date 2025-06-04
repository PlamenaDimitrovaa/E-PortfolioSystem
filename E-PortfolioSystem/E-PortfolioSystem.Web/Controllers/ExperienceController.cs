using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Services.Data.Services;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Experience;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var experience = await experienceService.GetByIdAsync(id);
            if (experience == null)
            {
                TempData[ErrorMessage] = "Данни за опит не са намерени!";
                return RedirectToAction("Resume", "Profile");
            }

            return View(experience);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData[ErrorMessage] = "Не са намерени данни за опита!";
                return RedirectToAction("Resume", "Profile");
            }

            var experienceFormModel = await experienceService.GetForEditByIdAsync(id);

            if (experienceFormModel == null)
            {
                TempData[ErrorMessage] = "Не са намерени данни за опита!";
                return RedirectToAction("Resume", "Profile");
            }

            return View(experienceFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ExperienceEditViewModel model)
        {
            if (id != model.Id)
            {
                TempData[ErrorMessage] = "Възникна грешка при търсенето на данни за опита!";
                return RedirectToAction("Resume", "Profile");
            }

            if (!ModelState.IsValid)
                return View(model);

            var success = await experienceService.UpdateAsync(id, model);

            if (!success)
            {
                TempData[ErrorMessage] = "Възникна грешка при редактирането на опита!";
                return RedirectToAction("Resume", "Profile");
            }

            TempData[SuccessMessage] = "Опитът е успешно редактиран.";
            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ExperienceEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState["StartDate"]?.Errors.Any(e => e.ErrorMessage.Contains("invalid")) == true)
                {
                    ModelState["StartDate"].Errors.Clear();
                    ModelState["StartDate"].Errors.Add("Полето 'Начална дата' е задължително и трябва да е валидна дата.");
                }

                return View(model);
            }

            var userId = User.GetId();
            await experienceService.AddAsync(model, userId!);
            TempData[SuccessMessage] = "Опитът е успешно добавен.";
            return RedirectToAction("Resume", "Profile");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await experienceService.DeleteAsync(id);
                TempData[SuccessMessage] = "Опитът е успешно изтрит!";
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка при изтриването на опита!";
                return RedirectToAction("Resume", "Profile");
            }

            return RedirectToAction("Resume", "Profile");
        }
    }
}

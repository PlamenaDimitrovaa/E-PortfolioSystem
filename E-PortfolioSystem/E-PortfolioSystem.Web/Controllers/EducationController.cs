using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Education;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        private readonly IEducationService educationService;

        public EducationController(IEducationService educationService)
        {
            this.educationService = educationService;
        }

        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var education = await educationService.GetByIdAsync(id);
                if (education == null)
                {
                    TempData[ErrorMessage] = "Данни за това образование не бяха намерени!";
                    return RedirectToAction("Resume", "Profile");
                }

                return View(education);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на детайлите за образованието.";
                return RedirectToAction("Resume", "Profile");
            }
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest();
                }

                var model = await educationService.GetEducationForEditAsync(id);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на формата за редактиране.";
                return RedirectToAction("Resume", "Profile");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EducationEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await educationService.UpdateEducationAsync(model);
                TempData[SuccessMessage] = "Образованието е успешно редактирано.";
                return RedirectToAction("Details", new { id = model.Id });
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Неуспешно редактиране на образованието";
                return RedirectToAction("Resume", "Profile");
            }
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EducationEditViewModel model)
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

            try
            {
                string userId = User.GetId();
                await this.educationService.AddEducationAsync(model, userId);
                TempData[SuccessMessage] = "Успешно добавихте образование!";
                return RedirectToAction("Resume", "Profile");
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при добавянето на образованието.";
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.educationService.DeleteEducationAsync(id);
                TempData[SuccessMessage] = "Успешно изтрихте образование!";
                return RedirectToAction("Resume", "Profile");
            }
            catch
            {
                TempData[ErrorMessage] = "Изтриването не беше успешно.";
                return RedirectToAction("Resume", "Profile");
            }
        }
    }
}

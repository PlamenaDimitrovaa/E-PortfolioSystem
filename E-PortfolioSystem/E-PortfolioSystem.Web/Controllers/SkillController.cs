using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Services.Data.Services;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Skill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        private readonly ISkillService skillService;
        private readonly IStudentService studentService;

        public SkillController(
            ISkillService skillService,
            IStudentService studentService)
        {
            this.skillService = skillService;
            this.studentService = studentService;
        }

        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var skill = await skillService.GetByIdAsync(id);
                if (skill == null)
                {
                    TempData[ErrorMessage] = "Умението не е намерено"!;
                    return RedirectToAction("Resume", "Profile");
                }

                return View(skill);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на детайлите за умението.";
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
                    TempData[ErrorMessage] = "Невалиден идентификатор на умението!";
                    return RedirectToAction("Resume", "Profile");
                }

                var model = await skillService.GetSkillForEditAsync(id);

                if (model == null)
                {
                    TempData[ErrorMessage] = "Невалидно умение!";
                    return RedirectToAction("Resume", "Profile");
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
        public async Task<IActionResult> Edit(SkillEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await skillService.UpdateSkillAsync(model);
                TempData[SuccessMessage] = "Умението е успешно редактирано.";
                return RedirectToAction("Details", new { id = model.Id });
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Неуспешно редактиране на умението!";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(SkillEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.GetId();
                if (userId != null)
                {
                    var studentId = await studentService.GetStudentIdByUserIdAsync(userId);
                    var skillId = await skillService.AddAsync(model, Guid.Parse(userId), studentId);
                    TempData[SuccessMessage] = "Успешно добавено умение!";
                    return RedirectToAction("Details", new { id = skillId });
                }

                TempData[ErrorMessage] = "Невалиден потребител!";
                return RedirectToAction("Resume", "Profile");
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при добавянето на умението.";
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var userId = User.GetId();
                if (userId != null)
                {
                    var studentId = await studentService.GetStudentIdByUserIdAsync(userId);
                    await skillService.DeleteAsync(id, studentId);
                    TempData[SuccessMessage] = "Умението е успешно изтрито.";
                }
                return RedirectToAction("Resume", "Profile");
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при изтриването на умението.";
                return RedirectToAction("Resume", "Profile");
            }
        }
    }
}

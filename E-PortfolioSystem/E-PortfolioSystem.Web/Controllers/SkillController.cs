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
            var skill = await skillService.GetByIdAsync(id);
            if (skill == null)
            {
                TempData[ErrorMessage] = "Умението не е намерено"!;
                return RedirectToAction("Resume", "Profile");
            }

            return View(skill);
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
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
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Неуспешно редактиране на умението!";
                return View(model);
            }

            TempData[SuccessMessage] = "Умението е успешно редактирано.";
            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SkillEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.GetId();
            if (userId != null)
            {
                var studentId = await studentService.GetStudentIdByUserId(userId);
                var skillId = await skillService.AddAsync(model, Guid.Parse(userId), studentId);
                return RedirectToAction("Details", new { id = skillId });
            }

            TempData[SuccessMessage] = "Успешно добавено умение!";
            return RedirectToAction("Resume", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var userId = User.GetId();
            if (userId != null)
            {
                var studentId = await studentService.GetStudentIdByUserId(userId);
                await skillService.DeleteAsync(id, studentId);
            }

            TempData[SuccessMessage] = "Успешно изтрито умение!";
            return RedirectToAction("Resume", "Profile");
        }
    }
}

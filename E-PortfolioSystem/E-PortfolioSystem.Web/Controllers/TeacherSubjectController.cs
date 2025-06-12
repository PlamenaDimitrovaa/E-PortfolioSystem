using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Subject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize(Roles = TeacherRoleName)]
    public class TeacherSubjectController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly ITeacherService teacherService;

        public TeacherSubjectController(
            ISubjectService subjectService,
            ITeacherService teacherService)
        {
            this.subjectService = subjectService;
            this.teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Subjects()
        {
            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);
                var subjects = await subjectService.GetSubjectsByTeacherAsync(teacherId);

                return View(subjects);
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на предметите.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                if (!await subjectService.IsTeacherOfSubjectAsync(teacherId, id))
                {
                    return Unauthorized();
                }

                var subjectId = Guid.Parse(id);
                var subject = await subjectService.GetTeacherSubjectDetailsAsync(subjectId);

                if (subject == null)
                {
                    return NotFound();
                }

                return View(subject);
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на детайлите за предмета.";
                return RedirectToAction(nameof(Subjects));
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new SubjectFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubjectFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                await subjectService.CreateAsync(model, teacherId);

                TempData[SuccessMessage] = "Предметът беше създаден успешно!";
                return RedirectToAction(nameof(Subjects));
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при създаването на предмета.";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var userId = User.GetId();
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                var subject = await subjectService.GetSubjectWithDocumentAsync(id);

                if (subject == null)
                {
                    return NotFound();
                }

                var model = new SubjectFormModel
                {
                    Name = subject.Name,
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на формата за редактиране.";
                return RedirectToAction("Subjects");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubjectFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                await subjectService.UpdateAsync(model, teacherId);

                TempData[SuccessMessage] = "Предметът беше редактиран успешно!";
                return RedirectToAction(nameof(Subjects));
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при редактрирането на предмета.";
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await subjectService.DeleteSubjectAsync(id);
                TempData["SuccessMessage"] = "Предметът и свързаните записи бяха успешно изтрити.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Грешка при изтриването";
            }

            return RedirectToAction("Subjects", "TeacherSubject");
        }
    }
}
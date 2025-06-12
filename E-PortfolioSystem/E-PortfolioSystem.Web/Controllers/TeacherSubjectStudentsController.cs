using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize(Roles = TeacherRoleName)]
    public class TeacherSubjectStudentsController : Controller
    {
        private readonly IStudentService studentService;
        private readonly ITeacherService teacherService;
        private readonly ISubjectService subjectService;

        public TeacherSubjectStudentsController(
            IStudentService studentService,
            ITeacherService teacherService,
            ISubjectService subjectService)
        {
            this.studentService = studentService;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string id)
        {
            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                if (!await subjectService.IsTeacherOfSubjectAsync(teacherId, id))
                {
                    return Unauthorized();
                }

                var students = await studentService.GetAllStudentsForSubjectAsync(id);
                ViewBag.SubjectId = id;

                return View(students);
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на студентите.";
                return RedirectToAction("Subjects", "TeacherSubject");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(string subjectId, string studentId)
        {
            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                if (!await subjectService.IsTeacherOfSubjectAsync(teacherId, subjectId))
                {
                    return Unauthorized();
                }

                if (!await studentService.IsStudentEnrolledInSubjectAsync(studentId, subjectId))
                {
                    await studentService.EnrollStudentInSubjectAsync(studentId, subjectId);
                    TempData[SuccessMessage] = "Студентът беше записан успешно!";
                }

                return RedirectToAction(nameof(Manage), new { id = subjectId });
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при записването на студента.";
                return RedirectToAction(nameof(Manage), new { id = subjectId });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string subjectId, string studentId)
        {
            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                if (!await subjectService.IsTeacherOfSubjectAsync(teacherId, subjectId))
                {
                    return Unauthorized();
                }

                await studentService.RemoveStudentFromSubjectAsync(studentId, subjectId);
                TempData[SuccessMessage] = "Студентът беше отписан успешно!";

                return RedirectToAction(nameof(Manage), new { id = subjectId });
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при отписването на студента.";
                return RedirectToAction(nameof(Manage), new { id = subjectId });
            }
        }

        [HttpGet]
        public async Task<IActionResult> StudentDetails(string subjectId, string studentId)
        {
            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                if (!await subjectService.IsTeacherOfSubjectAsync(teacherId, subjectId))
                {
                    return Unauthorized();
                }

                var details = await subjectService.GetStudentSubjectDetailsAsync(
                    Guid.Parse(subjectId),
                    Guid.Parse(studentId));

                if (details == null)
                {
                    TempData[ErrorMessage] = "Студентът не е намерен в този предмет.";
                    return RedirectToAction(nameof(Manage), new { id = subjectId });
                }

                return View(details);
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на детайлите за студента.";
                return RedirectToAction("Subjects", "TeacherSubject");
            }
        }
    }
} 
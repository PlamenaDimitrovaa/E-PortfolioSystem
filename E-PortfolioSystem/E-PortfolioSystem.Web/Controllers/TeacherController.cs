using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Student;
using E_PortfolioSystem.Web.ViewModels.Subject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly IStudentService studentService;
        private readonly ISubjectService subjectService;

        public TeacherController(
            ITeacherService teacherService,
            IStudentService studentService,
            ISubjectService subjectService)
        {
            this.teacherService = teacherService;
            this.studentService = studentService;
            this.subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var userId = User.GetId()!;
                var teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                var students = await studentService.GetStudentsByTeacherAsync(Guid.Parse(teacherId));
                var model = new List<StudentListViewModel>();

                foreach (var student in students)
                {
                    var subjects = await subjectService.GetSubjectsByTeacherAndStudentAsync(Guid.Parse(teacherId), Guid.Parse(student.Id));

                    model.Add(new StudentListViewModel
                    {
                        Id = student.Id,
                        FullName = student.FullName,
                        FacultyNumber = student.FacultyNumber,
                        IsEnrolled = student.IsEnrolled,
                        Subjects = subjects.Select(sub => new SubjectSimpleViewModel
                        {
                            Id = sub.Id.ToString(),
                            Name = sub.Name
                        }).ToList()
                    });
                }

                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на студентите.";
                return RedirectToAction("Index", "Home");
            }
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
        public async Task<IActionResult> SubjectDetails(string id)
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
        public IActionResult AddSubject()
        {
            var model = new SubjectFormModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubject(SubjectFormModel model)
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
        public async Task<IActionResult> EditSubject(Guid id)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubject(SubjectFormModel model)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSubject(Guid id)
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

            return RedirectToAction(nameof(Subjects));
        }

        [HttpGet]
        public async Task<IActionResult> ManageStudents(string id)
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
                return RedirectToAction(nameof(Subjects));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnrollStudent(string subjectId, string studentId)
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

                return RedirectToAction(nameof(ManageStudents), new { id = subjectId });
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при записването на студента.";
                return RedirectToAction(nameof(ManageStudents), new { id = subjectId });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveStudent(string subjectId, string studentId)
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

                return RedirectToAction(nameof(ManageStudents), new { id = subjectId });
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при отписването на студента.";
                return RedirectToAction(nameof(ManageStudents), new { id = subjectId });
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
                    return RedirectToAction(nameof(ManageStudents), new { id = subjectId });
                }

                return View(details);
            }
            catch (InvalidOperationException)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на детайлите за студента.";
                return RedirectToAction(nameof(Subjects));
            }
        }
    }
}

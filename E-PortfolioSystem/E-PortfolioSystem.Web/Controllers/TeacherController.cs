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
    }
}

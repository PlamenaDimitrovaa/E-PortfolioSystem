using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Services.Data.Services;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Subject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly IStudentService studentService;
        private readonly IWebHostEnvironment _environment;
        public SubjectController(
            ISubjectService subjectService,
            IStudentService studentService,
            IWebHostEnvironment environment)
        {
            this.subjectService = subjectService;
            this.studentService = studentService;
            _environment = environment;
        }
        public async Task<IActionResult> Subjects()
        {
            try
            {
                var studentId = await this.studentService.GetStudentIdByUserIdAsync(User.GetId());
                var subjects = await subjectService.GetSubjectsByStudentAsync(studentId);
                return View(subjects);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на предметите.";
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var userId = User.GetId();
                var studentId = await studentService.GetStudentIdByUserIdAsync(userId);
                var vm = await subjectService.GetSubjectDetailsAsync(id, Guid.Parse(studentId));

                if (vm == null)
                {
                    return NotFound();
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на детайлите за предмета.";
                return RedirectToAction("Subjects");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var subject = await subjectService.GetSubjectWithDocumentAsync(id);

                if (subject == null)
                {
                    return NotFound();
                }

                var model = new SubjectEditDocumentViewModel
                {
                    SubjectId = subject.Id,
                    Name = subject.Name,
                    IsAdmitted = subject.IsAdmitted,
                    TeacherFullName = subject.Teacher.User.FirstName + " " + subject.Teacher.User.LastName,
                    ExistingFilePath = subject.Project?.AttachedDocument?.FileLocation,
                    ExistingFileId = subject.Project?.AttachedDocument?.Id.ToString(),
                    ExistingFileName = subject.Project?.AttachedDocument?.FileName
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
        public async Task<IActionResult> Edit(SubjectEditDocumentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                if (model.NewFile != null && model.NewFile.Length > 0)
                {
                    var fileName = Path.GetFileName(model.NewFile.FileName);

                    var relativePath = Path.Combine("Uploaded", "Files", fileName);
                    var absolutePath = Path.Combine(_environment.WebRootPath, relativePath);

                    Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);

                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await model.NewFile.CopyToAsync(stream);
                    }

                    await subjectService.UpdateSubjectAttachedDocumentAsync(model.SubjectId, fileName, relativePath);
                }

                TempData[SuccessMessage] = "Предметът е успешно редактиран.";
                return RedirectToAction("Details", new { id = model.SubjectId });
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при редактирането на предмета.";
                return View(model);
            }
        }
    }
}

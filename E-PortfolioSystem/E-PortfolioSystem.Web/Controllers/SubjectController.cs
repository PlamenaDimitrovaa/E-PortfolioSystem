using E_PortfolioSystem.Services.Data.Interfaces;
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
        public async Task<IActionResult> AddProject(Guid id)
        {
            try
            {
                var userId = User.GetId();
                var studentId = await studentService.GetStudentIdByUserIdAsync(userId);
                var subject = await subjectService.GetSubjectDetailsAsync(id, Guid.Parse(studentId));

                if (subject == null)
                {
                    TempData[ErrorMessage] = "Предметът не е намерен.";
                    return RedirectToAction(nameof(Subjects));
                }

                if (!string.IsNullOrEmpty(subject.ProjectTitle))
                {
                    TempData[ErrorMessage] = "Вече има добавен проект към този предмет.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                var model = new SubjectProjectFormModel
                {
                    SubjectId = id.ToString(),
                    SubjectName = subject.Name
                };

                return View(model);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на формата.";
                return RedirectToAction(nameof(Subjects));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProject(SubjectProjectFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.GetId();
                await subjectService.AddProjectToSubjectAsync(model, userId);

                TempData[SuccessMessage] = "Проектът беше добавен успешно!";
                return RedirectToAction(nameof(Details), new { id = model.SubjectId });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка при добавянето на проекта.";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var userId = User.GetId();
                var studentId = await studentService.GetStudentIdByUserIdAsync(userId);

                var subject = await subjectService.GetSubjectWithDocumentAsync(id, Guid.Parse(studentId));

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
                    var uploadDirectory = Path.Combine(_environment.WebRootPath, "Uploaded", "Files");

                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }

                    var filePath = Path.Combine("Uploaded", "Files", fileName);
                    var absolutePath = Path.Combine(_environment.WebRootPath, filePath);

                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await model.NewFile.CopyToAsync(stream);
                    }

                    var userId = User.GetId();
                    var studentId = await studentService.GetStudentIdByUserIdAsync(userId);
                    await subjectService.UpdateSubjectAttachedDocumentAsync(model.SubjectId, Guid.Parse(studentId), fileName, filePath);

                    TempData[SuccessMessage] = "Документът беше успешно качен.";
                    return RedirectToAction("Details", new { id = model.SubjectId });
                }

                return RedirectToAction("Details", new { id = model.SubjectId });
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = $"Възникна грешка при редактирането на предмета: {ex.Message}";
                return View(model);
            }
        }
    }
}

namespace E_PortfolioSystem.Web.Controllers
{
    using E_PortfolioSystem.Services.Data.Interfaces;
    using E_PortfolioSystem.Web.ViewModels.Project;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using static E_PortfolioSystem.Common.NotificationMessagesConstants;

    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        private readonly IAttachedDocumentService _attachedDocumentService;

        public ProjectController(
            IProjectService projectService,
            IAttachedDocumentService attachedDocumentService)
        {
            this._projectService = projectService;
            _attachedDocumentService = attachedDocumentService;
        }

        public async Task<IActionResult> Projects()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var projects = await _projectService.GetAllByUserIdAsync(Guid.Parse(userId));

                return View(projects);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на проектите.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProjectFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (model.File != null && model.File.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploaded", "Files");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var fileName = Path.GetFileName(model.File.FileName); // You can sanitize if needed
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(stream);
                    }
                }

                await _projectService.SaveProject(model, userId);
                TempData[SuccessMessage] = "Успешно добавен проект";

                return RedirectToAction("Projects", "Project");
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при добавянето на проекта.";
                return View(model);
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var project = await _projectService.GetByIdAsync(id);

                if (project == null)
                {
                    TempData[ErrorMessage] = "Такъв проект не е намерен!";
                    return RedirectToAction("Projects", "Project");
                }

                var attachedDocuments = await _attachedDocumentService.GetAttachedDocumentsByProjectId(Guid.Parse(project.AttachedDocumentId));

                project.AttachedDocuments = attachedDocuments;

                return View(project);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на детайлите за проекта.";
                return RedirectToAction("Projects");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var model = await _projectService.GetProjectForEditAsync(id);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на формата за редактиране.";
                return RedirectToAction("Projects");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _projectService.UpdateProjectAsync(model);
                TempData[SuccessMessage] = "Проектът е успешно редактиран.";
                return RedirectToAction("Details", new { id = model.Id });
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при редактирането на проекта.";
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _projectService.DeleteProjectAsync(id);
                TempData[SuccessMessage] = "Проектът е изтрит успешно.";
                return RedirectToAction("Projects");
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при изтриването на проекта.";
                return RedirectToAction("Projects");
            }
        }
    }
}

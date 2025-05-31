namespace E_PortfolioSystem.Web.Controllers
{
    using E_PortfolioSystem.Services.Data.Interfaces;
    using E_PortfolioSystem.Services.Data.Services;
    using E_PortfolioSystem.Web.ViewModels.Project;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projects = await _projectService.GetAllByUserIdAsync(Guid.Parse(userId));

            return View(projects);
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
                return RedirectToAction("Add", "Project");
            }

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

        public async Task<IActionResult> Details(Guid id)
        {
            var project = await _projectService.GetByIdAsync(id);

            if (project == null)
            {
                TempData[ErrorMessage] = "Такъв проект не е намерен!";
                return RedirectToPage("Projects", "Project");
            }

            var attachedDocuments = await _attachedDocumentService.GetAttachedDocumentsByProjectId(Guid.Parse(project.AttachedDocumentId));

            project.AttachedDocuments = attachedDocuments;

            return View(project);
        }
    }
}

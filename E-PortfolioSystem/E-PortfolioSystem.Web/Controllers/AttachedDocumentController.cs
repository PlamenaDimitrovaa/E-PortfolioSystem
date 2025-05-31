using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class AttachedDocumentController : Controller
    {
        private readonly IAttachedDocumentService _attachedDocumentService;
        private readonly IWebHostEnvironment _environment;

        public AttachedDocumentController(
            IAttachedDocumentService attachedDocumentService,
            IWebHostEnvironment environment)
        {
            this._attachedDocumentService = attachedDocumentService;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile uploadedFile, [FromForm] AttachedDocumentFormModel model)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                var fileName = Path.GetFileName(uploadedFile.FileName);
                var savePath = Path.Combine("wwwroot/Uploads/Files", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

                model.FileName = fileName;
                model.FileLocation = savePath;
                model.FileContent = "Uploaded";
                model.UploadDate = DateTime.UtcNow;

                _attachedDocumentService.Add(model);

                TempData[SuccessMessage] = "Успешно прикачен документ";
                return RedirectToAction("Projects", "Project");
            }

            TempData[ErrorMessage] = "Невалиден файл!";
            ModelState.AddModelError("", "Моля, прикачете валиден файл.");
            return View(model);
        }

        public async Task<IActionResult> Download(Guid id)
        {
            var document = await _attachedDocumentService.FindAsync(id);

            if (document == null)
            {
                TempData[ErrorMessage] = "Неуспешно изтегляне на документа!";
                return RedirectToAction("Projects", "Project");
            }

            var filePath = Path.Combine(_environment.WebRootPath, document.FileLocation);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Файлът не беше намерен на сървъра.");
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "application/octet-stream", document.FileName);
        }
    }
}

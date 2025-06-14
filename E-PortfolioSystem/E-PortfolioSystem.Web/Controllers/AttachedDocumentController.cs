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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadDocument(IFormFile uploadedFile, [FromForm] AttachedDocumentFormModel model)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(uploadedFile.FileName);
                    var relativePath = Path.Combine("Uploaded", "Files", fileName);
                    var absolutePath = Path.Combine(_environment.WebRootPath, relativePath);

                    Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);

                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(stream);
                    }

                    model.FileName = fileName;
                    model.FileLocation = relativePath;
                    model.FileContent = "Uploaded";
                    model.UploadDate = DateTime.UtcNow;

                    _attachedDocumentService.Add(model);

                    TempData[SuccessMessage] = "Успешно прикачен документ";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    TempData[ErrorMessage] = "Възникна грешка при качването на документа.";
                    ModelState.AddModelError("", "Възникна грешка при обработката на файла.");
                    return View(model);
                }
            }

            TempData[ErrorMessage] = "Невалиден файл!";
            ModelState.AddModelError("", "Моля, прикачете валиден файл.");
            return View(model);
        }

        public async Task<IActionResult> Download(Guid id)
        {
            try
            {
                var document = await _attachedDocumentService.FindAsync(id);

                if (document == null)
                {
                    TempData[ErrorMessage] = "Неуспешно изтегляне на документа!";
                    return RedirectToAction("Index", "Home");
                }

                var filePath = Path.Combine(_environment.WebRootPath, document.FileLocation);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("Файлът не беше намерен на сървъра.");
                }

                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(fileBytes, "application/octet-stream", document.FileName);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при изтеглянето на документа.";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

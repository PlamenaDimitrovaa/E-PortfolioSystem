using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Services.Data.Services;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Certificate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class CertificateController : Controller
    {
        private readonly ICertificateService certificateService;
        private readonly IStudentService studentService;
        private readonly IAttachedDocumentService attachedDocumentService;

        public CertificateController(
            ICertificateService certificateService,
            IStudentService studentService,
            IAttachedDocumentService attachedDocumentService)
        {
            this.certificateService = certificateService;
            this.studentService = studentService;
            this.attachedDocumentService = attachedDocumentService;
        }

        public async Task<IActionResult> Details(string id)
        {
            var certificate = await certificateService.GetByIdAsync(id);
            if (certificate == null)
            {
                TempData[ErrorMessage] = "Сертификатът не е намерен"!;
                return RedirectToAction("Resume", "Profile");
            }

            var attachedDocuments = await attachedDocumentService.GetAttachedDocumentsByProjectId(Guid.Parse(certificate.AttachedDocumentId));

            certificate.AttachedDocuments = attachedDocuments;

            return View(certificate);
        }


        public IActionResult Add()
        {
            return View(new CertificateEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CertificateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Възникна грешка при добавянето на сертификат!";
                return View(model);
            }

            var userId = User.GetId();

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

                model.FilePath = filePath;
            }

            var studentId = studentService.GetStudentIdByUserId(userId);
            await certificateService.SaveCertificateAsync(model, studentId!);
            TempData[SuccessMessage] = "Успешно добавихте сертификат!";
            return RedirectToAction("Resume", "Profile");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await certificateService.GetCertificateForEditAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CertificateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Възникна грешка при редактирането на сертификат!";
                return View(model);
            }

            await certificateService.UpdateCertificateAsync(model);
            TempData[SuccessMessage] = "Успешно редактирахте сертификат!";
            return RedirectToAction("Details", new { id = model.Id });
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await certificateService.DeleteCertificateAsync(id);
            TempData[SuccessMessage] = "Успешно изтрихте сертификат!";
            return RedirectToAction("Resume", "Profile");
        }
    }
}

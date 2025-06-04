using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Services.Data.Services;
using Microsoft.AspNetCore.Authorization;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class CertificateController : Controller
    {
        private readonly ICertificateService certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            this.certificateService = certificateService;
        }

        public async Task<IActionResult> Details(string id)
        {
            var certificate = await certificateService.GetByIdAsync(id);
            if (certificate == null)
            {
                TempData[ErrorMessage] = "Сертификатът не е намерен"!;
                return RedirectToAction("Resume", "Profile");
            }

            return View(certificate);
        }
    }
}

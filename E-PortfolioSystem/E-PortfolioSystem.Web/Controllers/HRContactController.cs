using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.HRContact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class HRContactController : Controller
    {
        private readonly IHRContactService _hrContactService;
        private readonly INotificationService _notificationService;

        public HRContactController(
            IHRContactService hRContactService,
            INotificationService notificationService)
        {
            this._hrContactService = hRContactService;
            this._notificationService = notificationService;
        }

        public async Task<IActionResult> Messages()
        {
            var userId = Guid.Parse(User.GetId()!);
            var messages = User.IsInRole(HRRoleName)
                ? await _hrContactService.GetAllByHRUserIdAsync(userId)
                : await _hrContactService.GetAllByStudentUserIdAsync(userId);

            return View(messages);
        }

        public async Task<IActionResult> MyMessages()
        {
            var userId = Guid.Parse(User.GetId()!);
            var messages = await _hrContactService.GetAllByStudentUserIdAsync(userId);
            return View(messages);
        }

        [Authorize(Roles = HRRoleName)]
        public IActionResult Send(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Невалиден потребител.";
                return RedirectToAction("PublicProfiles", "HR");
            }

            var model = new HRContactViewModel
            {
                ToUserId = userId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = HRRoleName)]
        public async Task<IActionResult> Send(HRContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (string.IsNullOrEmpty(model.ToUserId))
            {
                ModelState.AddModelError("ToUserId", "Невалиден получател на съобщението.");
                return View(model);
            }

            try
            {
                Guid hrUserId = Guid.Parse(User.GetId()!);
                await _hrContactService.CreateAsync(model, hrUserId, Guid.Parse(model.ToUserId));

                await _notificationService.CreateHRContactNotificationAsync(
                    Guid.Parse(model.ToUserId),
                    Guid.Parse(model.ToUserId));

                TempData["SuccessMessage"] = "Успешно изпратихте съобщение!";
                return RedirectToAction("PublicProfiles", "HR");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при изпращането на съобщението.");
                return View(model);
            }
        }
    }
}

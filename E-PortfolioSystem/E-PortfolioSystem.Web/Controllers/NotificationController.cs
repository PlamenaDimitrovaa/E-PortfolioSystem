using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.GetId();
                var notifications = await _notificationService.GetUnreadNotificationsAsync(Guid.Parse(userId));
                return View(notifications);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "Възникна грешка при зареждането на нотификациите.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(Guid id)
        {
            try
            {
                await _notificationService.MarkNotificationAsReadAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Възникна грешка при маркирането на нотификацията като прочетена." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUnreadCount()
        {
            try
            {
                var userId = User.GetId();
                var count = await _notificationService.GetUnreadNotificationsCountAsync(Guid.Parse(userId));
                return Json(new { count });
            }
            catch (Exception ex)
            {
                return Json(new { count = 0 });
            }
        }
    }
}

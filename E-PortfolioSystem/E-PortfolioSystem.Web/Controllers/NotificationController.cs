using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

namespace E_PortfolioSystem.Web.Controllers
{
    using E_PortfolioSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static E_PortfolioSystem.Common.GeneralApplicationConstants;

    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                if (User.IsInRole(AdminRoleName))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Възникна грешка при обработката на заявката." });
        }
    }
}

namespace E_PortfolioSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class ProfileController : Controller
    {
        public IActionResult Resume()
        {
            return View();
        }
    }
}

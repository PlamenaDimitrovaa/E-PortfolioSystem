namespace E_PortfolioSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class ProjectController : Controller
    {
        public IActionResult Projects()
        {
            return View();
        }
    }
}

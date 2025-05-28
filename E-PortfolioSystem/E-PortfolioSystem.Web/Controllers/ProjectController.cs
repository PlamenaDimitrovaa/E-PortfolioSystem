namespace E_PortfolioSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ProjectController : Controller
    {
        public async Task<IActionResult> Projects()
        {
            return View();
        }
    }
}

namespace E_PortfolioSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ProfileController : Controller
    {
        public async Task<IActionResult> Resume()
        {
            return View();
        }
    }
}

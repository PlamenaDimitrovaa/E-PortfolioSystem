using E_PortfolioSystem.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;

namespace E_PortfolioSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var statistics = new
            {
                TotalUsers = await userManager.Users.CountAsync(),
                Students = (await userManager.GetUsersInRoleAsync(StudentRoleName)).Count,
                Teachers = (await userManager.GetUsersInRoleAsync(TeacherRoleName)).Count,
                HRs = (await userManager.GetUsersInRoleAsync(HRRoleName)).Count
            };

            return View(statistics);
        }
    }
} 
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Web.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static E_PortfolioSystem.Common.NotificationMessagesConstants;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Web.Controllers
{
    public class UserController : Controller
    {   
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfileService profileService;

        public UserController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IProfileService profileService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.profileService = profileService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Create profile with basic info
                await profileService.CreateProfileAsync(
                    user.Id, 
                    $"{model.FirstName} {model.LastName}");

                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                TempData[ErrorMessage] = "Възникна грешка при входа в приложението!";
                return View(model);
            }

            // Проверяваме дали потребителят е администратор
            var user = await userManager.FindByEmailAsync(model.Email);
            if (await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }
    }
}

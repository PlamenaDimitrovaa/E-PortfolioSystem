using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.HRContact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Web.Controllers
{
    public class HRContactController : Controller
    {
        private readonly IHRContactService _hrContactService;

        public HRContactController(IHRContactService hRContactService)
        {
            this._hrContactService = hRContactService;
        }
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(HRContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // TODO: Тук можеш да вземеш потребителите от контекста (примерно чрез User.Identity.Name)
            Guid hrUserId = Guid.Parse(User.GetId());        // текущ HR или системно зададен
            //Guid studentUserId = ...;   // този, към когото се отнася съобщението

            //await _hrContactService.CreateAsync(model, hrUserId, studentUserId);

            TempData["SuccessMessage"] = "Успешно изпрати съобщение!";
            return RedirectToAction("Resume", "Profile");
        }
    }
}

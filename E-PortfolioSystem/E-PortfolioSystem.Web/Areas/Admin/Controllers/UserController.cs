using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;
using E_PortfolioSystem.Web.Infrastructure.Middlewares;
using E_PortfolioSystem.Web.Infrastructure.Extensions;

namespace E_PortfolioSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly IStudentService studentService;
        private readonly ITeacherService teacherService;

        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IStudentService studentService,
            ITeacherService teacherService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.studentService = studentService;
            this.teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var users = await userManager.Users.ToListAsync();
            var userViewModels = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                userViewModels.Add(new UserRoleViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = roles.ToList()
                });
            }

            return View(userViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            // Проверяваме дали ролята съществува
            if (!await roleManager.RoleExistsAsync(role))
            {
                return BadRequest("Невалидна роля!");
            }

            try
            {
                // Премахваме всички текущи роли на потребителя
                var currentRoles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, currentRoles);

                // Задаваме новата роля
                await userManager.AddToRoleAsync(user, role);

                // Ако ролята е Студент, създаваме запис в таблицата Students
                if (role == StudentRoleName)
                {
                    await studentService.CreateStudentAsync(user.Id);
                }
                // Ако ролята е Преподавател, създаваме запис в таблицата Teachers
                else if (role == TeacherRoleName)
                {
                    await teacherService.CreateTeacherAsync(user.Id);
                }

                return RedirectToAction(nameof(Manage));
            }
            catch (InvalidOperationException ex)
            {
                // Ако възникне грешка при създаването на студент или преподавател, връщаме съобщение за грешка
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Manage));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Online()
        {
            var users = await userManager.Users.ToListAsync();
            var userViewModels = new List<OnlineUserViewModel>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                userViewModels.Add(new OnlineUserViewModel
                {
                    Id = user.Id.ToString(),
                    UserName = $"{user.FirstName} {user.LastName}",
                    Email = user.Email!,
                    Role = (roles.FirstOrDefault() ?? "Няма роля").ToFriendlyName(),
                    IsOnline = OnlineUsersMiddleware.CheckIfUserIsOnline(user.Id.ToString())
                });
            }

            return View(userViewModels);
        }
    }
} 
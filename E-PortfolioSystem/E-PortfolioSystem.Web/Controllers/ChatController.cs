using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IChatService chatService;
        private readonly UserManager<ApplicationUser> userManager;

        public ChatController(
            IChatService chatService,
            UserManager<ApplicationUser> userManager)
        {
            this.chatService = chatService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUserId = User.GetId();
            var chatUsers = await chatService.GetChatUsersAsync(currentUserId);
            return View(chatUsers);
        }

        public async Task<IActionResult> Chat(string userId)
        {
            var currentUserId = User.GetId();
            var chatHistory = await chatService.GetChatHistoryAsync(currentUserId, userId);
            ViewBag.OtherUserId = userId;

            var otherUser = await userManager.FindByIdAsync(userId);
            ViewBag.OtherUserName = otherUser?.FirstName + " " + otherUser?.LastName ?? "Потребител";

            return View(chatHistory);
        }

        [HttpGet]
        public async Task<IActionResult> GetUnreadCount()
        {
            var currentUserId = User.GetId();
            var count = await chatService.GetUnreadMessagesCountAsync(currentUserId);
            return Json(new { count });
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableUsers()
        {
            var currentUserId = User.GetId();
            var users = await userManager.Users
                .Where(u => u.Id.ToString() != currentUserId)
                .Select(u => new
                {
                    id = u.Id.ToString(),
                    name = u.UserName
                })
                .ToListAsync();

            return Json(users);
        }
    }
}

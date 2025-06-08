using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class ChatService : IChatService
    {
        private readonly EPortfolioDbContext dbContext;

        public ChatService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SaveMessageAsync(ChatMessage message)
        {
            await dbContext.ChatMessages.AddAsync(message);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChatMessageViewModel>> GetChatHistoryAsync(string userId1, string userId2)
        {
            var guid1 = Guid.Parse(userId1);
            var guid2 = Guid.Parse(userId2);

            var messages = await dbContext.ChatMessages
                .Include(m => m.Sender)
                .Where(m => (m.SenderId == guid1 && m.ReceiverId == guid2) ||
                           (m.SenderId == guid2 && m.ReceiverId == guid1))
                .OrderBy(m => m.Timestamp)
                .Select(m => new ChatMessageViewModel
                {
                    SenderId = m.SenderId.ToString(),
                    SenderName = m.Sender.UserName!,
                    Content = m.Content,
                    Timestamp = m.Timestamp,
                    IsRead = m.IsRead,
                    IsFromCurrentUser = m.SenderId == guid1
                })
                .ToListAsync();

            return messages;
        }

        public async Task<IEnumerable<ChatUserViewModel>> GetChatUsersAsync(string userId)
        {
            var userGuid = Guid.Parse(userId);

            var chatUsers = await dbContext.ChatMessages
                .Where(m => m.SenderId == userGuid || m.ReceiverId == userGuid)
                .Select(m => m.SenderId == userGuid ? m.ReceiverId : m.SenderId)
                .Distinct()
                .Select(otherUserId => new ChatUserViewModel
                {
                    UserId = otherUserId.ToString(),
                    UserName = dbContext.Users
                        .Where(u => u.Id == otherUserId)
                        .Select(u => u.UserName ?? "Deleted User")
                        .FirstOrDefault() ?? "Unknown User",
                    UserRole = dbContext.UserRoles
                        .Where(ur => ur.UserId == otherUserId)
                        .Join(dbContext.Roles,
                            ur => ur.RoleId,
                            r => r.Id,
                            (ur, r) => r.Name)
                        .FirstOrDefault() ?? "User",
                    UnreadMessagesCount = dbContext.ChatMessages.Count(m =>
                        m.SenderId == otherUserId && 
                        m.ReceiverId == userGuid && 
                        !m.IsRead),
                    LastMessageTime = dbContext.ChatMessages
                        .Where(m => (m.SenderId == userGuid && m.ReceiverId == otherUserId) ||
                                  (m.SenderId == otherUserId && m.ReceiverId == userGuid))
                        .OrderByDescending(m => m.Timestamp)
                        .Select(m => m.Timestamp)
                        .FirstOrDefault()
                })
                .OrderByDescending(u => u.LastMessageTime)
                .ToListAsync();

            return chatUsers;
        }

        public async Task MarkMessagesAsReadAsync(string currentUserId, string otherUserId)
        {
            var currentUserGuid = Guid.Parse(currentUserId);
            var otherUserGuid = Guid.Parse(otherUserId);

            var unreadMessages = await dbContext.ChatMessages
                .Where(m => m.SenderId == otherUserGuid && 
                           m.ReceiverId == currentUserGuid && 
                           !m.IsRead)
                .ToListAsync();

            foreach (var message in unreadMessages)
            {
                message.IsRead = true;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<int> GetUnreadMessagesCountAsync(string userId)
        {
            var userGuid = Guid.Parse(userId);
            return await dbContext.ChatMessages
                .CountAsync(m => m.ReceiverId == userGuid && !m.IsRead);
        }
    }
}

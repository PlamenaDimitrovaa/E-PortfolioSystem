using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Web.ViewModels;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IChatService
    {
        Task SaveMessageAsync(ChatMessage message);
        Task<IEnumerable<ChatMessageViewModel>> GetChatHistoryAsync(string userId1, string userId2);
        Task<IEnumerable<ChatUserViewModel>> GetChatUsersAsync(string userId);
        Task MarkMessagesAsReadAsync(string currentUserId, string otherUserId);
        Task<int> GetUnreadMessagesCountAsync(string userId);
    }
}

using E_PortfolioSystem.Web.ViewModels.Notification;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationViewModel>> GetUnreadNotificationsAsync(Guid userId);
        Task GenerateDeadlineNotificationsAsync();
        Task MarkNotificationAsReadAsync(Guid notificationId);
        Task<int> GetUnreadNotificationsCountAsync(Guid userId);       
        Task CreateNotificationAsync(Guid userId, string title, string content);
        Task CreateHRContactNotificationAsync(Guid userId, Guid hrContactId);
        Task<IEnumerable<NotificationViewModel>> GetHRContactNotificationsAsync(Guid userId);
    }
}

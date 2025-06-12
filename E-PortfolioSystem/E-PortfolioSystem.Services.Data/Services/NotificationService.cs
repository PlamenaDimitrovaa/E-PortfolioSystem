using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Notification;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class NotificationService : INotificationService
    {
        private readonly EPortfolioDbContext _dbContext;

        public NotificationService(EPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<NotificationViewModel>> GetUnreadNotificationsAsync(Guid userId)
        {
            var notifications = await _dbContext.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            var result = new List<NotificationViewModel>();
            foreach (var n in notifications)
            {
                DateTime? deadline = null;
                // Опит за намиране на deadline по subject name
                var subject = await _dbContext.Subjects.Include(s => s.Project)
                    .FirstOrDefaultAsync(s => s.Name == n.Title || ("Записване в предмет: " + s.Name) == n.Title);
                if (subject?.Project?.Deadline != null)
                {
                    deadline = subject.Project.Deadline;
                }
                result.Add(new NotificationViewModel
                {
                    Id = n.Id,
                    Message = n.Content,
                    CreatedOn = n.CreatedAt ?? DateTime.UtcNow,
                    IsRead = n.IsRead,
                    SubjectName = n.Title,
                    ProjectDeadline = deadline
                });
            }
            return result;
        }

        public async Task GenerateDeadlineNotificationsAsync()
        {
            var now = DateTime.UtcNow;
            var fiveDaysFromNow = now.AddDays(5);

            // Намираме всички предмети с проекти, чийто краен срок е след 5 дни
            var subjectsWithDeadlines = await _dbContext.Subjects
                .Include(s => s.Project)
                .Include(s => s.StudentSubjects)
                    .ThenInclude(ss => ss.Student)
                .Where(s => s.Project != null &&
                           s.Project.Deadline.HasValue &&
                           s.Project.Deadline.Value.Date == fiveDaysFromNow.Date &&
                           s.Project.AttachedDocument == null)
                .ToListAsync();

            foreach (var subject in subjectsWithDeadlines)
            {
                foreach (var studentSubject in subject.StudentSubjects)
                {
                    // Проверяваме дали вече няма създадена нотификация за този студент и предмет
                    var existingNotification = await _dbContext.Notifications
                        .AnyAsync(n => n.UserId == studentSubject.Student.UserId &&
                                     n.Title == subject.Name &&
                                     n.CreatedAt.HasValue &&
                                     n.CreatedAt.Value.Date == now.Date);

                    if (!existingNotification)
                    {
                        var notification = new Notification
                        {
                            UserId = studentSubject.Student.UserId,
                            Title = subject.Name,
                            Content = $"Наближава крайният срок за предаване на проект по предмет {subject.Name}! Остават 5 дни до крайния срок ({subject.Project!.Deadline:dd.MM.yyyy}). Моля, прикачете документ към проекта.",
                            CreatedAt = now,
                            IsRead = false
                        };

                        await _dbContext.Notifications.AddAsync(notification);
                    }
                }
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task MarkNotificationAsReadAsync(Guid notificationId)
        {
            var notification = await _dbContext.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetUnreadNotificationsCountAsync(Guid userId)
        {
            return await _dbContext.Notifications
                .CountAsync(n => n.UserId == userId && !n.IsRead);
        }

        public async Task CreateNotificationAsync(Guid userId, string title, string content)
        {
            var notification = new Notification
            {
                UserId = userId,
                Title = title,
                Content = content,
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };
            await _dbContext.Notifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();
        }
    }
}

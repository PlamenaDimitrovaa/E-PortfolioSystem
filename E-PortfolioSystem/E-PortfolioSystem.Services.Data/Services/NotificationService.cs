using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Notification;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class NotificationService : INotificationService
    {
        private readonly EPortfolioDbContext dbContext;

        public NotificationService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<NotificationViewModel>> GetUnreadNotificationsAsync(Guid userId)
        {
            return await dbContext.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationViewModel
                {
                    Id = n.Id,
                    Message = n.Content,
                    CreatedOn = n.CreatedAt ?? DateTime.UtcNow,
                    IsRead = n.IsRead,
                    SubjectName = n.Title
                })
                .ToListAsync();
        }

        public async Task GenerateDeadlineNotificationsAsync()
        {
            var fiveDaysFromNow = DateTime.UtcNow.AddDays(5);

            var subjectsWithDeadlines = await dbContext.Subjects
                .Include(s => s.Project)
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Student)
                .Where(s => s.Project != null && s.Project.Deadline <= fiveDaysFromNow)
                .ToListAsync();

            foreach (var subject in subjectsWithDeadlines)
            {
                foreach (var studentSubject in subject.StudentSubjects)
                {
                    var existingNotification = await dbContext.Notifications
                        .AnyAsync(n => n.UserId == studentSubject.Student.UserId &&
                                     n.Title == subject.Name &&
                                     n.CreatedAt >= DateTime.UtcNow.AddDays(-1));

                    if (!existingNotification)
                    {
                        var notification = new Notification
                        {
                            Id = Guid.NewGuid(),
                            Title = subject.Name,
                            Content = $"Краен срок за проект по {subject.Name}: {subject.Project.Deadline:dd.MM.yyyy}",
                            CreatedAt = DateTime.UtcNow,
                            IsRead = false,
                            UserId = studentSubject.Student.UserId
                        };

                        await dbContext.Notifications.AddAsync(notification);
                    }
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task MarkNotificationAsReadAsync(Guid notificationId)
        {
            var notification = await dbContext.Notifications
                .FirstOrDefaultAsync(n => n.Id == notificationId);

            if (notification != null)
            {
                notification.IsRead = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetUnreadNotificationsCountAsync(Guid userId)
        {
            return await dbContext.Notifications
                .CountAsync(n => n.UserId == userId && !n.IsRead);
        }

        public async Task CreateNotificationAsync(Guid userId, string title, string content)
        {
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Title = title,
                Content = content,
                CreatedAt = DateTime.UtcNow,
                IsRead = false,
                UserId = userId
            };

            await dbContext.Notifications.AddAsync(notification);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateHRContactNotificationAsync(Guid userId, Guid hrContactId)
        {
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Title = "Ново съобщение от HR",
                Content = "Получихте ново съобщение от HR специалист. Моля, проверете вашите съобщения.",
                CreatedAt = DateTime.UtcNow,
                IsRead = false,
                UserId = userId
            };

            await dbContext.Notifications.AddAsync(notification);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<NotificationViewModel>> GetHRContactNotificationsAsync(Guid userId)
        {
            return await dbContext.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationViewModel
                {
                    Id = n.Id,
                    Message = n.Content,
                    CreatedOn = n.CreatedAt ?? DateTime.UtcNow,
                    IsRead = n.IsRead,
                    SubjectName = n.Title
                })
                .ToListAsync();
        }
    }
}

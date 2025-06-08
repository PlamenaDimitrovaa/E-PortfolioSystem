using System;

namespace E_PortfolioSystem.Web.ViewModels.Notification
{
    public class NotificationViewModel
    {
        public Guid Id { get; set; }

        public string Message { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public bool IsRead { get; set; }

        public string SubjectName { get; set; } = null!;

        public DateTime ProjectDeadline { get; set; }
    }
} 
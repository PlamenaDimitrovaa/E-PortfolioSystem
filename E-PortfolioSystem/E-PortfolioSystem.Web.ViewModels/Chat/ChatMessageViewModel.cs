namespace E_PortfolioSystem.Web.ViewModels
{
    public class ChatMessageViewModel
    {
        public string SenderId { get; set; } = null!;
        public string SenderName { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public bool IsFromCurrentUser { get; set; }
    }
} 
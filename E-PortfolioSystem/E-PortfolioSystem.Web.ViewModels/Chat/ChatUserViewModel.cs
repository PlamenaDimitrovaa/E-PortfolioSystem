namespace E_PortfolioSystem.Web.ViewModels
{
    public class ChatUserViewModel
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? UserRole { get; set; }
        public int UnreadMessagesCount { get; set; }
        public DateTime? LastMessageTime { get; set; }
    }
} 
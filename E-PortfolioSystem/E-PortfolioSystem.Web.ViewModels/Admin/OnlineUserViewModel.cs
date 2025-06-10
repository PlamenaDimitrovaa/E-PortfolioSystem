namespace E_PortfolioSystem.Web.ViewModels.Admin
{
    public class OnlineUserViewModel
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool IsOnline { get; set; }
    }
} 
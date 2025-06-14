namespace E_PortfolioSystem.Web.ViewModels.Recommendation
{
    public class RecommendationViewModel
    {
        public string Id { get; set; } = null!;
        public string FromUserId { get; set; } = null!;
        public string ToUserId { get; set; } = null!;
        public string FromUserFullName { get; set; } = null!;
        public string? ToUserFullName { get; set; }
        public string Text { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
} 
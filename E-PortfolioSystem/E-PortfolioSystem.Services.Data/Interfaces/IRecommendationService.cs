using E_PortfolioSystem.Web.ViewModels.Recommendation;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IRecommendationService
    {
        Task<IEnumerable<RecommendationViewModel>> GetRecommendationsForUserAsync(string userId);
        Task AddRecommendationAsync(string fromUserId, string toUserId, string text);
        Task<RecommendationViewModel?> GetRecommendationByIdAsync(string id);
        Task UpdateRecommendationAsync(string id, string text);
        Task DeleteRecommendationAsync(string id);
        Task<bool> IsOwnerAsync(string recommendationId, string userId);
    }
}

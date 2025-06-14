using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Recommendation;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly EPortfolioDbContext dbContext;

        public RecommendationService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<RecommendationViewModel>> GetRecommendationsForUserAsync(string userId)
        {
            return await dbContext.Recommendations
                .Where(r => r.ToUserId.ToString() == userId)
                .Select(r => new RecommendationViewModel
                {
                    Id = r.Id.ToString(),
                    FromUserId = r.FromUserId.ToString(),
                    ToUserId = r.ToUserId.ToString(),
                    FromUserFullName = r.FromUser.FirstName + " " + r.FromUser.LastName,
                    Text = r.Text,
                    CreatedAt = r.CreatedAt
                })
                .ToListAsync();
        }

        public async Task AddRecommendationAsync(string fromUserId, string toUserId, string text)
        {
            var recommendation = new Recommendation
            {
                FromUserId = Guid.Parse(fromUserId),
                ToUserId = Guid.Parse(toUserId),
                Text = text,
                CreatedAt = DateTime.UtcNow
            };
            await dbContext.Recommendations.AddAsync(recommendation);
            await dbContext.SaveChangesAsync();
        }

        public async Task<RecommendationViewModel?> GetRecommendationByIdAsync(string id)
        {
            return await dbContext.Recommendations
                .Where(r => r.Id.ToString() == id)
                .Select(r => new RecommendationViewModel
                {
                    Id = r.Id.ToString(),
                    FromUserId = r.FromUserId.ToString(),
                    ToUserId = r.ToUserId.ToString(),
                    FromUserFullName = r.FromUser.FirstName + " " + r.FromUser.LastName,
                    Text = r.Text,
                    CreatedAt = r.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateRecommendationAsync(string id, string text)
        {
            var recommendation = await dbContext.Recommendations
                .FirstOrDefaultAsync(r => r.Id.ToString() == id);

            if (recommendation == null)
            {
                throw new InvalidOperationException("Препоръката не е намерена.");
            }

            recommendation.Text = text;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecommendationAsync(string id)
        {
            var recommendation = await dbContext.Recommendations
                .FirstOrDefaultAsync(r => r.Id.ToString() == id);

            if (recommendation == null)
            {
                throw new InvalidOperationException("Препоръката не е намерена.");
            }

            dbContext.Recommendations.Remove(recommendation);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsOwnerAsync(string recommendationId, string userId)
        {
            return await dbContext.Recommendations
                .AnyAsync(r => r.Id.ToString() == recommendationId && r.FromUserId.ToString() == userId);
        }
    }
}

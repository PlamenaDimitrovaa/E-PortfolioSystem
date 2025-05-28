using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly EPortfolioDbContext dbContext;

        public RecommendationService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

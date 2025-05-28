using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly EPortfolioDbContext dbContext;

        public EvaluationService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

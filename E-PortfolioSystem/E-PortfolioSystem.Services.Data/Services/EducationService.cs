using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class EducationService : IEducationService
    {
        private readonly EPortfolioDbContext dbContext;

        public EducationService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

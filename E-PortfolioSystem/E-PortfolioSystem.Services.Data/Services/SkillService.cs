using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class SkillService : ISkillService
    {
        private readonly EPortfolioDbContext dbContext;

        public SkillService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

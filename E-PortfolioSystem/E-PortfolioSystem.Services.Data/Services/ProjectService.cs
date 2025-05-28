using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class ProjectService : IProjectService
    {
        private readonly EPortfolioDbContext dbContext;

        public ProjectService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

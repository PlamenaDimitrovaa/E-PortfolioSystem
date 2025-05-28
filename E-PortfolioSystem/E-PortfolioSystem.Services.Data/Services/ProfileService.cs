using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class ProfileService : IProfileService
    {
        private readonly EPortfolioDbContext dbContext;

        public ProfileService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

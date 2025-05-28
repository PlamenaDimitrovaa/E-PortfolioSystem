using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class EmailService : IEmailService
    {
        private readonly EPortfolioDbContext dbContext;

        public EmailService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

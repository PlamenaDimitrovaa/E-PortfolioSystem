using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class ContactService : IContactService
    {
        private readonly EPortfolioDbContext dbContext;

        public ContactService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

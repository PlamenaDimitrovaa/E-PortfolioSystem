using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class AttachedDocumentService : IAttachedDocumentService
    {
        private readonly EPortfolioDbContext dbContext;

        public AttachedDocumentService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

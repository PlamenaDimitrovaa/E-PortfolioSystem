using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly EPortfolioDbContext dbContext;

        public CertificateService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

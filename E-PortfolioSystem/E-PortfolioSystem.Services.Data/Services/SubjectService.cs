using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly EPortfolioDbContext dbContext;

        public SubjectService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

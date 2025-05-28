using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly EPortfolioDbContext dbContext;

        public TeacherService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

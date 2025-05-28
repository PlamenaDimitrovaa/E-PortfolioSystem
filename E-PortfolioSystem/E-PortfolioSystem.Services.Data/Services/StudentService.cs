using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class StudentService : IStudentService
    {
        private readonly EPortfolioDbContext dbContext;

        public StudentService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

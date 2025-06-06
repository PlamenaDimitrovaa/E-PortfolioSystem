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

        public string GetStudentIdByUserId(string userId)
        {
            return dbContext.Students
              .Where(s => s.UserId.ToString() == userId).FirstOrDefault().Id.ToString();
        }

        public async Task<string> GetStudentIdByUserIdAsync(string userId)
        {
            return dbContext.Students
                .Where(s => s.UserId.ToString() == userId).FirstOrDefault().Id.ToString();
        }
    }
}

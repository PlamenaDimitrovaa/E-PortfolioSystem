using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var student = dbContext.Students
                .Where(s => s.UserId.ToString() == userId)
                .FirstOrDefault();

            if (student == null)
            {
                throw new InvalidOperationException($"Не е намерен студент с потребителско ID: {userId}");
            }

            return student.Id.ToString();
        }

        public async Task<string> GetStudentIdByUserIdAsync(string userId)
        {
            var student = await dbContext.Students
                .Where(s => s.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                throw new InvalidOperationException($"Не е намерен студент с потребителско ID: {userId}");
            }

            return student.Id.ToString();
        }
    }
}

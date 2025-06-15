using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly EPortfolioDbContext dbContext;

        public TeacherService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string GetTeacherIdByUserId(string userId)
        {
            var teacher = dbContext.Teachers
                .Where(t => t.UserId.ToString() == userId)
                .FirstOrDefault();

            if (teacher == null)
            {
                throw new InvalidOperationException($"Не е намерен преподавател с потребителско ID: {userId}");
            }

            return teacher.Id.ToString();
        }

        public async Task<string> GetTeacherIdByUserIdAsync(string userId)
        {
            var teacher = await dbContext.Teachers
                .Where(t => t.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (teacher == null)
            {
                throw new InvalidOperationException($"Не е намерен преподавател с потребителско ID: {userId}");
            }

            return teacher.Id.ToString();
        }

        public async Task CreateTeacherAsync(Guid userId)
        {
            var existingTeacher = await dbContext.Teachers
                .FirstOrDefaultAsync(t => t.UserId == userId);

            if (existingTeacher != null)
            {
                throw new InvalidOperationException($"Вече съществува преподавател с потребителско ID: {userId}");
            }

            var teacher = new Teacher
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
        }
    }
}

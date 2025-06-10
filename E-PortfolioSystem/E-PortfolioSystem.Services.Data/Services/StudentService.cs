using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Student;
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

        public async Task<string> GetStudentIdByUserIdAsync(string userId)
        {
            var student = await dbContext.Students
                .FirstOrDefaultAsync(s => s.UserId.ToString() == userId);

            if (student == null)
            {
                throw new InvalidOperationException("Student not found");
            }

            return student.Id.ToString();
        }

        public string GetStudentIdByUserId(string userId)
        {
            var student = dbContext.Students
                .FirstOrDefault(s => s.UserId.ToString() == userId);

            if (student == null)
            {
                throw new InvalidOperationException("Student not found");
            }

            return student.Id.ToString();
        }

        public async Task<bool> StudentExistsByUserIdAsync(string userId)
        {
            return await dbContext.Students
                .AnyAsync(s => s.UserId.ToString() == userId);
        }

        public async Task<IEnumerable<StudentListViewModel>> GetAllStudentsForSubjectAsync(string subjectId)
        {
            var enrolledStudentIds = await dbContext.StudentsSubjects
                .Where(ss => ss.SubjectId.ToString() == subjectId)
                .Select(ss => ss.StudentId)
                .ToListAsync();

            var students = await dbContext.Students
                .Include(s => s.User)
                .Select(s => new StudentListViewModel
                {
                    Id = s.Id.ToString(),
                    FullName = s.User.FirstName + " " + s.User.LastName,
                    FacultyNumber = s.FacultyNumber,
                    IsEnrolled = enrolledStudentIds.Contains(s.Id)
                })
                .OrderBy(s => s.FullName)
                .ToListAsync();

            return students;
        }

        public async Task EnrollStudentInSubjectAsync(string studentId, string subjectId)
        {
            var studentSubject = new StudentSubject
            {
                StudentId = Guid.Parse(studentId),
                SubjectId = Guid.Parse(subjectId),
                EnrolledOn = DateTime.UtcNow
            };

            await dbContext.StudentsSubjects.AddAsync(studentSubject);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveStudentFromSubjectAsync(string studentId, string subjectId)
        {
            var studentSubject = await dbContext.StudentsSubjects
                .FirstOrDefaultAsync(ss => 
                    ss.StudentId.ToString() == studentId && 
                    ss.SubjectId.ToString() == subjectId);

            if (studentSubject != null)
            {
                dbContext.StudentsSubjects.Remove(studentSubject);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> IsStudentEnrolledInSubjectAsync(string studentId, string subjectId)
        {
            return await dbContext.StudentsSubjects
                .AnyAsync(ss => 
                    ss.StudentId.ToString() == studentId && 
                    ss.SubjectId.ToString() == subjectId);
        }

        public async Task CreateStudentAsync(Guid userId)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                FacultyNumber = GenerateFacultyNumber()
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
        }

        private string GenerateFacultyNumber()
        {
            // Генерира факултетен номер във формат: година + 5 случайни цифри
            // Например: 23XXXXX
            var year = DateTime.UtcNow.Year.ToString().Substring(2);
            var random = new Random();
            var number = random.Next(10000, 99999);

            return $"{year}{number}";
        }
    }
}

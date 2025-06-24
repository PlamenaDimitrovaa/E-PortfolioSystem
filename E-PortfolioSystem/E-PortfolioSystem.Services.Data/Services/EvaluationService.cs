using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly EPortfolioDbContext dbContext;
        private readonly INotificationService notificationService;

        public EvaluationService(EPortfolioDbContext dbContext, INotificationService notificationService)
        {
            this.dbContext = dbContext;
            this.notificationService = notificationService;
        }
        public async Task<StudentEvaluationViewModel> GetEvaluationFormAsync(Guid subjectId, Guid studentId)
        {
            var student = await dbContext.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null || student.User == null)
            {
                throw new InvalidOperationException("Студентът не е намерен.");
            }

            var studentSubject = await dbContext.StudentsSubjects
                .FirstOrDefaultAsync(ss => ss.StudentId == studentId && ss.SubjectId == subjectId);

            Project? studentProject = null;
            if (studentSubject?.ProjectId != null)
            {
                studentProject = await dbContext.Projects
                    .Include(p => p.AttachedDocument)
                    .FirstOrDefaultAsync(p => p.Id == studentSubject.ProjectId);
            }

            return new StudentEvaluationViewModel
            {
                StudentId = studentId.ToString(),
                SubjectId = subjectId.ToString(),
                StudentName = student.User.FirstName + " " + student.User.LastName,
                FacultyNumber = student.FacultyNumber,
                ProjectTitle = studentProject?.Title,
                AttachedDocumentUrl = studentProject?.AttachedDocument?.FileLocation,
                AttachedDocumentId = studentProject?.AttachedDocument?.Id.ToString()
            };
        }

        private async Task<Guid> GetStudentUserIdAsync(Guid studentId)
        {
            var student = await dbContext.Students
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
            {
                throw new InvalidOperationException("Студентът не е намерен.");
            }

            return student.UserId;
        }

        public async Task SubmitEvaluationAsync(StudentEvaluationViewModel model, Guid teacherId)
        {
            var subjectId = Guid.Parse(model.SubjectId);
            var studentId = Guid.Parse(model.StudentId);

            var studentSubject = await dbContext.StudentsSubjects.FirstOrDefaultAsync(ss => ss.StudentId == studentId && ss.SubjectId == subjectId);
            if (studentSubject == null || studentSubject.ProjectId == null)
            {
                throw new InvalidOperationException("Няма проект за този студент по този предмет.");
            }
            var project = await dbContext.Projects.FirstOrDefaultAsync(p => p.Id == studentSubject.ProjectId);
            if (project == null)
            {
                throw new InvalidOperationException("Проектът не е намерен.");
            }
            var evaluation = new Evaluation
            {
                Id = Guid.NewGuid(),
                TeacherId = teacherId,
                SubjectId = subjectId,
                ProjectId = project.Id,
                SubjectGrade = model.SubjectGrade,
                ProjectGrade = model.ProjectGrade,
                Feedback = model.Feedback,
                EvaluationType = model.EvaluationType,
                CreatedAt = DateTime.UtcNow
            };

            dbContext.Evaluations.Add(evaluation);
            project.EvaluationId = evaluation.Id;
            studentSubject.EvaluationId = evaluation.Id;
            await dbContext.SaveChangesAsync();

            var student = await dbContext.Students.Include(s => s.User).FirstOrDefaultAsync(s => s.Id == studentId);
            var subject = await dbContext.Subjects.FirstOrDefaultAsync(s => s.Id == subjectId);
            if (student != null && subject != null)
            {
                string title = $"Оценка по предмет: {subject.Name}";
                string content = $"Получихте нова оценка по предмет {subject.Name}.";
                await notificationService.CreateNotificationAsync(student.UserId, title, content);
            }
        }
    }
}

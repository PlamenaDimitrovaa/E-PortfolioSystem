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

        public EvaluationService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<StudentEvaluationViewModel> GetEvaluationFormAsync(Guid subjectId, Guid studentId)
        {
            var student = await dbContext.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            var project = await dbContext.Projects
                .FirstOrDefaultAsync(p => p.UserId == student.UserId && p.Evaluation.SubjectId == subjectId);

            return new StudentEvaluationViewModel
            {
                StudentId = studentId.ToString(),
                SubjectId = subjectId.ToString(),
                StudentName = student.User.FirstName + " " + student.User.LastName,
                FacultyNumber = student.FacultyNumber,
                ProjectTitle = project?.Title ?? "Няма проект",
                AttachedDocumentUrl = project?.AttachedDocument?.FileLocation
            };
        }

        public async Task SubmitEvaluationAsync(StudentEvaluationViewModel model, Guid teacherId)
        {
            var evaluation = new Evaluation
            {
                Id = Guid.NewGuid(),
                TeacherId = teacherId,
                SubjectId = Guid.Parse(model.SubjectId),
                SubjectGrade = model.SubjectGrade,
                ProjectGrade = model.ProjectGrade,
                Feedback = model.Feedback,
                EvaluationType = model.EvaluationType,
                CreatedAt = DateTime.UtcNow
            };

            var subject = await dbContext.Subjects.FirstAsync(s => s.Id.ToString() == model.SubjectId);
            var student = await dbContext.Students
                .Include(s => s.Projects)
                .FirstAsync(s => s.Id.ToString() == model.StudentId);
            var project = student.Projects.FirstOrDefault(p => p.Evaluation?.SubjectId == subject.Id);

            if (project != null)
            {
                project.Evaluation = evaluation;
                project.EvaluationId = evaluation.Id;
                evaluation.ProjectId = project.Id;
            }

            subject.Evaluation = evaluation;
            subject.EvaluationId = evaluation.Id;

            dbContext.Evaluations.Add(evaluation);
            await dbContext.SaveChangesAsync();
        }
    }
}

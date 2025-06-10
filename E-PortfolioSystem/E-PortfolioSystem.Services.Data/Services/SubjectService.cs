using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Subject;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly EPortfolioDbContext dbContext;

        public SubjectService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SubjectViewModel>> GetSubjectsByStudentAsync(string studentId)
        {
            return await this.dbContext
                .StudentsSubjects
                .Where(ss => ss.StudentId.ToString() == studentId)
                .Select(ss => new SubjectViewModel
                {
                    Id = ss.Subject.Id.ToString(),
                    Name = ss.Subject.Name,
                    TeacherFullName = ss.Subject.Teacher.User.FirstName + " " + ss.Subject.Teacher.User.LastName
                })
                .ToListAsync();
        }

        public async Task<SubjectDetailsViewModel?> GetSubjectDetailsAsync(Guid subjectId, Guid studentId)
        {
            var subject = await dbContext.Subjects
                .Include(s => s.Teacher)
                    .ThenInclude(t => t.User)
                .Include(s => s.Evaluation)
                .Include(s => s.Project)
                    .ThenInclude(p => p!.AttachedDocument)
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

            if (subject == null || subject.Teacher == null || subject.Teacher.User == null)
            {
                return null;
            }

            var enrolledOn = subject.StudentSubjects
                .FirstOrDefault(ss => ss.StudentId == studentId)?.EnrolledOn;

            var vm = new SubjectDetailsViewModel
            {
                Id = subject.Id.ToString(),
                Name = subject.Name,
                IsAdmitted = subject.IsAdmitted,
                TeacherName = subject.Teacher.User.FirstName + " " + subject.Teacher.User.LastName,
                EnrolledOn = enrolledOn,

                SubjectGrade = subject.Evaluation?.SubjectGrade,
                ProjectGrade = subject.Evaluation?.ProjectGrade,
                Feedback = subject.Evaluation?.Feedback,
                EvaluationType = subject.Evaluation?.EvaluationType,
                EvaluationDate = subject.Evaluation?.CreatedAt,

                ProjectTitle = subject.Project?.Title,
                ProjectDescription = subject.Project?.Description,
                ProjectLink = subject.Project?.Link,
                DocumentFilePath = subject.Project?.AttachedDocument?.FileLocation,
                DocumentFileName = subject.Project?.AttachedDocument?.FileName,
                DocumentId = subject.Project?.AttachedDocument?.Id.ToString()
            };

            return vm;
        }

        public async Task UpdateSubjectAttachedDocumentAsync(Guid subjectId, string fileName, string filePath)
        {
            var subject = await dbContext.Subjects
                .Include(s => s.Project)
                .ThenInclude(p => p.AttachedDocument)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

            if (subject?.Project == null)
            {
                return;
            }

            var existingDoc = subject.Project.AttachedDocument;

            if (existingDoc != null)
            {
                existingDoc.FileName = fileName;
                existingDoc.FileLocation = filePath;
                existingDoc.UploadDate = DateTime.UtcNow;
            }
            else
            {
                var newDoc = new AttachedDocument
                {
                    FileName = fileName,
                    FileLocation = filePath,
                    UploadDate = DateTime.UtcNow,
                    DocumentType = "Проект", // или от логиката
                    Description = "Качен от студент"
                };

                subject.Project.AttachedDocument = newDoc;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<Subject?> GetSubjectWithDocumentAsync(Guid subjectId)
        {
            return await dbContext.Subjects
                .Include(s => s.Project)
                .ThenInclude(p => p.AttachedDocument)
                .Include(s => s.Teacher)
                .ThenInclude(t => t.User)
                .FirstOrDefaultAsync(s => s.Id == subjectId);
        }

        public async Task<IEnumerable<TeacherSubjectViewModel>> GetSubjectsByTeacherAsync(string teacherId)
        {
            return await dbContext.Subjects
                .Where(s => s.TeacherId.ToString() == teacherId)
                .Select(s => new TeacherSubjectViewModel
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    IsAdmitted = s.IsAdmitted,
                    EnrolledStudentsCount = s.StudentSubjects.Count
                })
                .ToListAsync();
        }

        public async Task<bool> IsTeacherOfSubjectAsync(string teacherId, string subjectId)
        {
            if (!Guid.TryParse(subjectId, out var parsedSubjectId))
            {
                return false;
            }

            return await dbContext.Subjects
                .AnyAsync(s => s.Id == parsedSubjectId && s.TeacherId.ToString() == teacherId);
        }

        public async Task CreateAsync(SubjectFormModel model, string teacherId)
        {
            var subject = new Subject
            {
                Name = model.Name,
                IsAdmitted = true,
                TeacherId = Guid.Parse(teacherId)
            };

            await dbContext.Subjects.AddAsync(subject);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubjectFormModel model, string teacherId)
        {
            if (!Guid.TryParse(model.Id, out var subjectId))
            {
                throw new ArgumentException("Невалиден идентификатор на предмет.");
            }

            var subject = await dbContext.Subjects.FindAsync(subjectId);

            if (subject == null)
            {
                throw new InvalidOperationException("Предметът не е намерен.");
            }

            subject.Name = model.Name;

            await dbContext.SaveChangesAsync();
        }
    }
}

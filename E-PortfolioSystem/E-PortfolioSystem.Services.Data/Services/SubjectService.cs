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
        private readonly IAttachedDocumentService attachedDocumentService;
        private readonly INotificationService notificationService;

        public SubjectService(EPortfolioDbContext dbContext, IAttachedDocumentService attachedDocumentService, INotificationService notificationService)
        {
            this.dbContext = dbContext;
            this.attachedDocumentService = attachedDocumentService;
            this.notificationService = notificationService;
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
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

            if (subject == null || subject.Teacher == null || subject.Teacher.User == null)
            {
                return null;
            }

            var studentSubject = subject.StudentSubjects.FirstOrDefault(ss => ss.StudentId == studentId);
            var enrolledOn = studentSubject?.EnrolledOn;
            Project? studentProject = null;
            Evaluation? evaluation = null;
            if (studentSubject?.ProjectId != null)
            {
                studentProject = await dbContext.Projects.Include(p => p.AttachedDocument).FirstOrDefaultAsync(p => p.Id == studentSubject.ProjectId);
            }
            if (studentSubject?.EvaluationId != null)
            {
                evaluation = await dbContext.Evaluations.FirstOrDefaultAsync(e => e.Id == studentSubject.EvaluationId);
            }
            var vm = new SubjectDetailsViewModel
            {
                Id = subject.Id.ToString(),
                Name = subject.Name,
                IsAdmitted = subject.IsAdmitted,
                TeacherName = subject.Teacher.User.FirstName + " " + subject.Teacher.User.LastName,
                EnrolledOn = enrolledOn,
                SubjectGrade = evaluation?.SubjectGrade,
                ProjectGrade = evaluation?.ProjectGrade,
                Feedback = evaluation?.Feedback,
                EvaluationType = evaluation?.EvaluationType,
                EvaluationDate = evaluation?.CreatedAt,
                ProjectTitle = studentProject?.Title,
                ProjectDescription = studentProject?.Description,
                ProjectLink = studentProject?.Link,
                DocumentFilePath = studentProject?.AttachedDocument?.FileLocation,
                DocumentFileName = studentProject?.AttachedDocument?.FileName,
                DocumentId = studentProject?.AttachedDocument?.Id.ToString()
            };
            return vm;
        }

        public async Task UpdateSubjectAttachedDocumentAsync(Guid subjectId, Guid studentId, string fileName, string filePath)
        {
            var subject = await dbContext.Subjects
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

            if (subject == null)
            {
                throw new InvalidOperationException("Предметът не е намерен.");
            }

            var studentSubject = subject.StudentSubjects.FirstOrDefault(ss => ss.StudentId == studentId);
            if (studentSubject == null)
            {
                throw new InvalidOperationException("Студентът не е записан за този предмет.");
            }

            if (studentSubject.ProjectId == null)
            {
                throw new InvalidOperationException("Няма проект свързан с този предмет.");
            }

            var project = await dbContext.Projects
                .Include(p => p.AttachedDocument)
                .FirstOrDefaultAsync(p => p.Id == studentSubject.ProjectId);

            if (project == null)
            {
                throw new InvalidOperationException("Проектът не е намерен.");
            }

            var existingDoc = project.AttachedDocument;

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
                    Id = Guid.NewGuid(),
                    FileName = fileName,
                    FileLocation = filePath,
                    UploadDate = DateTime.UtcNow,
                    DocumentType = "Проект",
                    Description = "Качен от студент",
                    ProjectId = project.Id
                };

                project.AttachedDocument = newDoc;
                project.AttachedDocumentId = newDoc.Id;
                dbContext.AttachedDocuments.Add(newDoc);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<Subject?> GetSubjectWithDocumentAsync(Guid subjectId, Guid studentId)
        {
            var subject = await dbContext.Subjects
                .Include(s => s.StudentSubjects)
                .Include(s => s.Teacher)
                .ThenInclude(t => t.User)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

            if (subject == null)
            {
                return null;
            }

            var studentSubject = subject.StudentSubjects.FirstOrDefault(ss => ss.StudentId == studentId);
            if (studentSubject?.ProjectId != null)
            {
                var project = await dbContext.Projects
                    .Include(p => p.AttachedDocument)
                    .FirstOrDefaultAsync(p => p.Id == studentSubject.ProjectId);
                
                // Временно задаваме проекта на subject за съвместимост
                subject.Project = project;
            }

            return subject;
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

        public async Task DeleteSubjectAsync(Guid subjectId)
        {
            var subject = await dbContext.Subjects
                .Include(s => s.StudentSubjects)
                .Include(s => s.Evaluation)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

            if (subject == null)
            {
                throw new InvalidOperationException("Предметът не съществува.");
            }

            if (subject.StudentSubjects.Any())
            {
                dbContext.StudentsSubjects.RemoveRange(subject.StudentSubjects);
            }

            if (subject.Evaluation != null)
            {
                dbContext.Evaluations.Remove(subject.Evaluation);
            }

            dbContext.Subjects.Remove(subject);

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubjectViewModel>> GetSubjectsByTeacherAndStudentAsync(Guid teacherId, Guid studentId)
        {
            return await dbContext.Subjects
                .Where(s => s.TeacherId == teacherId)
                .Select(s => new SubjectViewModel
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    TeacherFullName = s.Teacher.User.FirstName + " " + s.Teacher.User.LastName
                })
                .ToListAsync();
        }

        private async Task<Guid> GetStudentIdByUserIdAsync(string userId)
        {
            var student = await dbContext.Students
                .FirstOrDefaultAsync(s => s.UserId.ToString() == userId);

            if (student == null)
            {
                throw new InvalidOperationException("Студентът не е намерен.");
            }

            return student.Id;
        }

        public async Task<bool> AddProjectToSubjectAsync(Guid subjectId, SubjectProjectFormModel model, string userId)
        {
            var subject = await dbContext.Subjects.Include(s => s.Teacher).ThenInclude(t => t.User).FirstOrDefaultAsync(s => s.Id == subjectId);
            if (subject == null)
                throw new InvalidOperationException("Предметът не е намерен.");
            if (subject.Teacher == null)
                throw new InvalidOperationException("Няма преподавател за този предмет.");
            if (subject.Teacher.User == null)
                throw new InvalidOperationException("Преподавателят няма свързан потребителски профил.");

            var studentId = await GetStudentIdByUserIdAsync(userId);
            var student = await dbContext.Students.Include(s => s.User).FirstOrDefaultAsync(s => s.Id == studentId);

            var project = new Project
            {
                UserId = Guid.Parse(userId),
                Title = model.Title,
                Description = model.Description,
                Link = model.Link,
                CreatedAt = DateTime.UtcNow,
                IsApproved = true
            };
            if (model.AttachedFile != null)
            {
                var document = await attachedDocumentService.SaveDocumentAsync(
                    model.AttachedFile,
                    "Проект",
                    "Прикачен файл към проект");
                project.AttachedDocumentId = document.Id;
            }
            dbContext.Projects.Add(project);
            await dbContext.SaveChangesAsync();

            var studentSubject = await dbContext.StudentsSubjects.FirstOrDefaultAsync(ss => ss.StudentId == studentId && ss.SubjectId == subjectId);
            if (studentSubject != null)
            {
                studentSubject.ProjectId = project.Id;
                await dbContext.SaveChangesAsync();
            }

            if (subject.Teacher != null && subject.Teacher.User != null && student?.User != null)
            {
                string title = $"Нов проект по предмет: {subject.Name}";
                string content = $"Студент {student.User.FirstName} {student.User.LastName} добави нов проект по предмет {subject.Name}.";
                await notificationService.CreateNotificationAsync(subject.Teacher.UserId, title, content);
            }
            return true;
        }

        public async Task<TeacherSubjectDetailsViewModel?> GetTeacherSubjectDetailsAsync(Guid subjectId)
        {
            var subject = await dbContext.Subjects
                .Include(s => s.Teacher)
                    .ThenInclude(t => t.User)
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

            if (subject == null || subject.Teacher == null || subject.Teacher.User == null)
            {
                return null;
            }

            return new TeacherSubjectDetailsViewModel
            {
                Id = subject.Id.ToString(),
                Name = subject.Name,
                IsAdmitted = subject.IsAdmitted,
                TeacherName = subject.Teacher.User.FirstName + " " + subject.Teacher.User.LastName,
                EnrolledStudentsCount = subject.StudentSubjects.Count
            };
        }

        public async Task<StudentSubjectDetailsViewModel?> GetStudentSubjectDetailsAsync(Guid subjectId, Guid studentId)
        {
            var subject = await dbContext.Subjects
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

            if (subject == null)
            {
                return null;
            }

            var studentSubject = subject.StudentSubjects
                .FirstOrDefault(ss => ss.StudentId == studentId);

            if (studentSubject == null)
            {
                return null;
            }

            var student = await dbContext.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null || student.User == null)
            {
                return null;
            }

            Project? studentProject = null;
            if (studentSubject.ProjectId != null)
            {
                studentProject = await dbContext.Projects
                    .Include(p => p.AttachedDocument)
                    .FirstOrDefaultAsync(p => p.Id == studentSubject.ProjectId);
            }

            Evaluation? evaluation = null;
            if (studentSubject.EvaluationId != null)
            {
                evaluation = await dbContext.Evaluations.FirstOrDefaultAsync(e => e.Id == studentSubject.EvaluationId);
            }

            return new StudentSubjectDetailsViewModel
            {
                StudentId = student.Id.ToString(),
                StudentName = $"{student.User.FirstName} {student.User.LastName}",
                SubjectId = subject.Id.ToString(),
                SubjectName = subject.Name,
                EnrolledOn = studentSubject.EnrolledOn,
                ProjectTitle = studentProject?.Title,
                ProjectDescription = studentProject?.Description,
                ProjectLink = studentProject?.Link,
                DocumentFileName = studentProject?.AttachedDocument?.FileName,
                DocumentFilePath = studentProject?.AttachedDocument?.FileLocation,
                DocumentId = studentProject?.AttachedDocument?.Id.ToString(),
                SubjectGrade = evaluation?.SubjectGrade,
                ProjectGrade = evaluation?.ProjectGrade,
                Feedback = evaluation?.Feedback,
                EvaluationType = evaluation?.EvaluationType,
                EvaluationDate = evaluation?.CreatedAt
            };
        }

        public async Task AddProjectToSubjectAsync(SubjectProjectFormModel model, string userId)
        {
            if (!Guid.TryParse(model.SubjectId, out var subjectId))
            {
                throw new ArgumentException("Невалиден идентификатор!");
            }
            await AddProjectToSubjectAsync(subjectId, model, userId);
        }
    }
}

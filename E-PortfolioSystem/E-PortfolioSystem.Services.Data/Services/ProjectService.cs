using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using E_PortfolioSystem.Web.ViewModels.Project;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class ProjectService : IProjectService
    {
        private readonly EPortfolioDbContext dbContext;

        public ProjectService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = await dbContext.Projects
            .Include(p => p.AttachedDocument)
            .FirstOrDefaultAsync(p => p.Id == id);

                if (project == null)
                {
                    throw new InvalidOperationException("Проектът не е намерен.");
                }

                if (project.AttachedDocument != null)
                {
                    var filePath = Path.Combine("wwwroot", project.AttachedDocument.FileLocation.Replace('/', Path.DirectorySeparatorChar));
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    dbContext.AttachedDocuments.Remove(project.AttachedDocument);
                }

            dbContext.Projects.Remove(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectFormModel>> GetAllByUserIdAsync(Guid userId)
        {
            return await dbContext.Projects
                .Where(p => p.UserId == userId && p.ImageUrl != null && p.ImageUrl != "")
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new ProjectFormModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Link = p.Link,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<ProjectDetailsViewModel?> GetByIdAsync(Guid id)
        {
            var project = await dbContext.Projects
              .Where(p => p.Id == id)
              .Select(p => new ProjectDetailsViewModel
              {
                  Id = p.Id.ToString(),
                  Title = p.Title,
                  Description = p.Description,
                  Link = p.Link,
                  ImageUrl = p.ImageUrl,
                  Deadline = p.Deadline,
                  CreatedAt = p.CreatedAt,
                  AttachedDocumentId = p.AttachedDocumentId.ToString()
              })
              .FirstOrDefaultAsync();

            return project;
        }

        public async Task<ProjectEditViewModel> GetProjectForEditAsync(Guid id)
        {
            var project = await dbContext.Projects
                .Include(p => p.AttachedDocument)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                throw new InvalidOperationException("Проектът не е намерен.");
            }

            var model = new ProjectEditViewModel
            {
                Id = project.Id.ToString(),
                Title = project.Title,
                Description = project.Description,
                Link = project.Link,
                ImageUrl = project.ImageUrl,
                Deadline = project.Deadline,
                DocumentDescription = project.AttachedDocument?.Description,
                DocumentType = project.AttachedDocument?.DocumentType,
                AttachedDocument = project.AttachedDocument == null ? null : new AttachedDocumentFormModel
                {
                    Id = project.AttachedDocumentId.ToString() ?? "",
                    FileName = project.AttachedDocument.FileName,
                    FileLocation = project.AttachedDocument.FileLocation,
                    DocumentType = project.AttachedDocument.DocumentType,
                    Description = project.AttachedDocument.Description,
                    UploadDate = project.AttachedDocument.UploadDate
                }
            };

            return model;
        }

        public async Task SaveProject(ProjectFormModel model, string? userId)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Link = model.Link,
                ImageUrl = model.ImageUrl,
                Deadline = model.Deadline,
                CreatedAt = DateTime.UtcNow,
                UserId = Guid.Parse(userId)
            };

            if (model.File != null && model.File.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await model.File.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();
                var base64Content = Convert.ToBase64String(fileBytes);

                var document = new AttachedDocument
                {
                    Id = Guid.NewGuid(),
                    FileName = model.File.FileName,
                    FileContent = "File Content",
                    UploadDate = DateTime.UtcNow,
                    FileLocation = $"Uploaded/Files/{model.File.FileName}",
                    DocumentType = model.DocumentType ?? "Документ",
                    Description = model.DocumentDescription,
                    ProjectId = project.Id
                };

                project.AttachedDocumentId = document.Id;
                project.AttachedDocument = document;

                dbContext.AttachedDocuments.Add(document);
                await dbContext.SaveChangesAsync();

                dbContext.Projects.Add(project);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateProjectAsync(ProjectEditViewModel model)
        {
            var projectId = Guid.Parse(model.Id!);

            var project = await dbContext.Projects
                .Include(p => p.AttachedDocument)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                throw new InvalidOperationException("Проектът не е намерен.");
            }

            project.Title = model.Title;
            project.Description = model.Description;
            project.Link = model.Link;
            project.ImageUrl = model.ImageUrl;
            project.Deadline = model.Deadline;

            if (model.File != null && model.File.Length > 0)
            {
                var uploadPath = Path.Combine("wwwroot", "Uploaded", "Files");
                Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, model.File.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }

                var fileBytes = await File.ReadAllBytesAsync(filePath);
                var base64Content = Convert.ToBase64String(fileBytes);

                var document = new AttachedDocument
                {
                    Id = Guid.NewGuid(),
                    FileName = model.File.FileName,
                    FileContent = "File Content",
                    UploadDate = DateTime.UtcNow,
                    FileLocation = $"Uploaded/Files/{model.File.FileName}",
                    DocumentType = model.DocumentType ?? "Документ",
                    Description = model.DocumentDescription,
                    ProjectId = project.Id
                };

                // Remove old document if exists
                if (project.AttachedDocument != null)
                {
                    dbContext.AttachedDocuments.Remove(project.AttachedDocument);
                }

                project.AttachedDocument = document;
                project.AttachedDocumentId = document.Id;

                dbContext.AttachedDocuments.Add(document);
            }
            else if (project.AttachedDocument != null)
            {
                // Обновяване на мета данни при липса на нов файл
                project.AttachedDocument.Description = model.DocumentDescription;
                project.AttachedDocument.DocumentType = model.DocumentType ?? "Документ";
            }

            await dbContext.SaveChangesAsync();
        }
    }
}

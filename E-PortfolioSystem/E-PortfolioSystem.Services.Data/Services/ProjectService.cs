using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
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

        public async Task<IEnumerable<ProjectFormModel>> GetAllByUserIdAsync(Guid userId)
        {
            return await dbContext
            .Projects
            .Where(p => p.UserId == userId)
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

                dbContext.AttachedDocuments.Add(document);
                await dbContext.SaveChangesAsync();

                dbContext.Projects.Add(project);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

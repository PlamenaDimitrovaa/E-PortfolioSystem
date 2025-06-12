using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using E_PortfolioSystem.Web.ViewModels.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class AttachedDocumentService : IAttachedDocumentService
    {
        private readonly EPortfolioDbContext dbContext;

        public AttachedDocumentService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(AttachedDocumentFormModel model)
        {
            var entity = new AttachedDocument
            {
                DocumentType = model.DocumentType,
                FileName = model.FileName,
                Description = model.Description,
                FileContent = model.FileContent,
                UploadDate = model.UploadDate,
                FileLocation = model.FileLocation,
                //ProjectId = model.ProjectId
            };

            dbContext.AttachedDocuments.Add(entity);
            dbContext.SaveChanges();
        }

        public async Task<AttachedDocument?> FindAsync(Guid id)
        {
            return await dbContext.AttachedDocuments
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<AttachedDocumentFormModel>> GetAttachedDocumentsByProjectId(Guid id)
        {
            return await dbContext
           .AttachedDocuments
           .Where(p => p.Id == id)
           .Select(p => new AttachedDocumentFormModel 
           {
               Id = p.Id.ToString(),
               DocumentType = p.DocumentType,
               Description = p.Description,
               FileName = p.FileName,
               FileContent = p.FileContent,
               FileLocation = p.FileLocation,
               UploadDate = p.UploadDate
           })
           .ToListAsync();
        }

        public async Task<AttachedDocument> SaveDocumentAsync(IFormFile file, string documentType, string? description = null)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Невалиден файл.");
            }

            var fileName = Path.GetFileName(file.FileName);
            var relativePath = Path.Combine("Uploaded", "Files", fileName);
            var uploadPath = Path.Combine("wwwroot", relativePath);

            Directory.CreateDirectory(Path.GetDirectoryName(uploadPath)!);

            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var document = new AttachedDocument
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                FileContent = "File Content",
                UploadDate = DateTime.UtcNow,
                FileLocation = relativePath.Replace('\\', '/'),
                DocumentType = documentType,
                Description = description
            };

            dbContext.AttachedDocuments.Add(document);
            await dbContext.SaveChangesAsync();

            return document;
        }
    }
}

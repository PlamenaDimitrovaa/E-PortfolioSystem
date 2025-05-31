using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using E_PortfolioSystem.Web.ViewModels.Project;
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
    }
}

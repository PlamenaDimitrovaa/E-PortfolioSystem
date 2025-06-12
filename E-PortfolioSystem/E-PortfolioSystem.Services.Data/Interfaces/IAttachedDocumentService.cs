using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using Microsoft.AspNetCore.Http;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IAttachedDocumentService
    {
        void Add(AttachedDocumentFormModel model);
        Task<AttachedDocument?> FindAsync(Guid id);
        Task<IEnumerable<AttachedDocumentFormModel>> GetAttachedDocumentsByProjectId(Guid id);
        Task<AttachedDocument> SaveDocumentAsync(IFormFile file, string documentType, string? description = null);
    }
}

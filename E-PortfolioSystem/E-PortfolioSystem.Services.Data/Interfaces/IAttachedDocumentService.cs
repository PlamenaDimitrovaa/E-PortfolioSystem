using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Web.ViewModels.AttachedDocument;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IAttachedDocumentService
    {
        void Add(AttachedDocumentFormModel model);
        Task<AttachedDocument?> FindAsync(Guid id);
        Task<IEnumerable<AttachedDocumentFormModel>> GetAttachedDocumentsByProjectId(Guid id);
    }
}

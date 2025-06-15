using E_PortfolioSystem.Web.ViewModels.Certificate;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface ICertificateService
    {
        Task<IEnumerable<CertificateViewModel>> GetAllByUserIdAsync(string? id);
        Task<CertificateDetailsViewModel?> GetByIdAsync(string id);
        Task SaveCertificateAsync(CertificateEditViewModel model, string studentId);
        Task<CertificateEditViewModel> GetCertificateForEditAsync(Guid id);
        Task UpdateCertificateAsync(CertificateEditViewModel model);
        Task DeleteCertificateAsync(Guid id);
    }
}

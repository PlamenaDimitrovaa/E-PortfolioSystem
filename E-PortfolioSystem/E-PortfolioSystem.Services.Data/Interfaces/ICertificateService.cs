
using E_PortfolioSystem.Web.ViewModels.Certificate;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface ICertificateService
    {
        Task<IEnumerable<CertificateViewModel>> GetAllByUserIdAsync(string? id);
        Task<CertificateDetailsViewModel?> GetByIdAsync(string id);
    }
}

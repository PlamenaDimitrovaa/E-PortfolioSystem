using E_PortfolioSystem.Web.ViewModels.HRContact;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IHRContactService
    {
        Task CreateAsync(HRContactViewModel model, Guid hrUserId, Guid studentUserId);
        Task<IEnumerable<HRContactViewModel>> GetAllByHRUserIdAsync(Guid hrUserId);
        Task<IEnumerable<HRContactViewModel>> GetAllByStudentUserIdAsync(Guid studentUserId);
        Task<HRContactViewModel?> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}

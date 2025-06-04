using E_PortfolioSystem.Web.ViewModels.HRContact;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IHRContactService
    {
        Task CreateAsync(HRContactViewModel model, Guid hrUserId, Guid studentUserId);
    }
}

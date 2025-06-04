
using E_PortfolioSystem.Web.ViewModels.Profile;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetProfileByUserIdAsync(string? id);
    }
}

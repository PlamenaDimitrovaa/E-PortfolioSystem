using E_PortfolioSystem.Web.ViewModels.Profile;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetProfileByUserIdAsync(string? id);
        Task CreateProfileAsync(Guid userId, string fullName);
        Task<bool> ExistsByUserIdAsync(Guid userId);
        Task UpdateProfileAsync(Guid userId, string fullName, string phone, string bio, string location, string imageUrl, bool isPublic);
    }
}

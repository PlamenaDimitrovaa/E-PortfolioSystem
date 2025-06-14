using E_PortfolioSystem.Web.ViewModels.Profile;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IProfileService
    {
        Task<IEnumerable<ProfileViewModel>> GetAllPublicProfilesAsync(string? searchTerm = null, string? location = null, int page = 1, int pageSize = 9);
        Task<int> GetTotalPublicProfilesCountAsync(string? searchTerm = null, string? location = null);
        Task<ProfileViewModel?> GetProfileByUserIdAsync(string userId);
        Task CreateProfileAsync(Guid userId, string fullName);
        Task<bool> ExistsByUserIdAsync(Guid userId);
        Task UpdateProfileAsync(Guid userId, string fullName, string phone, string bio, string location, string imageUrl, bool isPublic);
    }
}

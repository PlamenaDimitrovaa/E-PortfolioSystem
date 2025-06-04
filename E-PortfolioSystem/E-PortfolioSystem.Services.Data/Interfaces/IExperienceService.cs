using E_PortfolioSystem.Web.ViewModels.Experience;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IExperienceService
    {
        Task<ExperienceDetailsViewModel?> GetByIdAsync(string id);
        Task<IEnumerable<ExperienceViewModel>> GetAllByUserIdAsync(string? id);
        Task<ExperienceEditViewModel?> GetForEditByIdAsync(string id);
        Task<bool> UpdateAsync(string id, ExperienceEditViewModel model);
        Task AddAsync(ExperienceEditViewModel model, string userId);
        Task DeleteAsync(string id);
    }
}

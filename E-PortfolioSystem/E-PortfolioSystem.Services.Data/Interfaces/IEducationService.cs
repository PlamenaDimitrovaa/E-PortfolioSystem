using E_PortfolioSystem.Web.ViewModels.Education;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationViewModel>> GetAllByUserIdAsync(string? id);
        Task<EducationDetailsViewModel> GetByIdAsync(string id);
        Task<EducationEditViewModel?> GetEducationForEditAsync(string id);
        Task UpdateEducationAsync(EducationEditViewModel model);
        Task AddEducationAsync(EducationEditViewModel model, string userId);
        Task DeleteEducationAsync(string educationId);
    }
}

using E_PortfolioSystem.Web.ViewModels.Project;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IProjectService
    {
        Task DeleteProjectAsync(Guid id);
        Task<IEnumerable<ProjectFormModel>> GetAllByUserIdAsync(Guid userId);
        Task<ProjectDetailsViewModel?> GetByIdAsync(Guid id);
        Task<ProjectEditViewModel> GetProjectForEditAsync(Guid id);
        Task SaveProject(ProjectFormModel model, string? userId);
        Task UpdateProjectAsync(ProjectEditViewModel model);
    }
}

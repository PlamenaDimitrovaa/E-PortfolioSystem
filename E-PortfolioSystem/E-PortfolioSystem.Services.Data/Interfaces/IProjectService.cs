using E_PortfolioSystem.Web.ViewModels.Project;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectFormModel>> GetAllByUserIdAsync(Guid userId);

        Task<ProjectDetailsViewModel?> GetByIdAsync(Guid id);
        Task SaveProject(ProjectFormModel model, string? userId);
    }
}

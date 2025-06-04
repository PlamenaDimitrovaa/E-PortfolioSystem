using E_PortfolioSystem.Web.ViewModels.Skill;
using System.Security.Claims;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillViewModel>> GetAllByUserIdAsync(string? id);
        Task<SkillDetailsViewModel?> GetByIdAsync(string id);
        Task<SkillEditViewModel?> GetSkillForEditAsync(string id);
        Task UpdateSkillAsync(SkillEditViewModel model);
        Task DeleteAsync(string id, string studentId);
        Task<Guid> AddAsync(SkillEditViewModel model, Guid userId, string studentId);
    }
}

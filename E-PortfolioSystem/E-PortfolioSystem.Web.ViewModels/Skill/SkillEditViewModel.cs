using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.Skill;

namespace E_PortfolioSystem.Web.ViewModels.Skill
{
    public class SkillEditViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Полето 'Име' е задължително.")]
        [StringLength(SkillNameMaxLength, MinimumLength = SkillNameMinLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Ниво' е задължително.")]
        [StringLength(LevelMaxLength, MinimumLength = LevelMinLength)]
        public string Level { get; set; } = null!;
    }
}

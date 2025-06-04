using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.Skill
{
    public class SkillEditViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Полето 'Име' е задължително.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Ниво' е задължително.")]
        public string Level { get; set; } = null!;
    }
}

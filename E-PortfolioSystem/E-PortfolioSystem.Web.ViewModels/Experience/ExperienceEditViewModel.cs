using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.Experience;

namespace E_PortfolioSystem.Web.ViewModels.Experience
{
    public class ExperienceEditViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Полето 'Компания' е задължително.")]
        [StringLength(CompanyMaxLength, MinimumLength = CompanyMinLength)]
        public string Company { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Професия' е задължително.")]
        [StringLength(ProfessionMaxLength, MinimumLength = ProfessionMinLength)]
        public string Profession { get; set; } = null!;
        public string? Location { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Полето 'Начална дата' е задължително.")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Полето 'Сектор' е задължително.")]
        public string Sector { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.Education;

namespace E_PortfolioSystem.Web.ViewModels.Education
{
    public class EducationEditViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Полето 'Учебно заведение' е задължително.")]
        [StringLength(InstitutionMaxLength, MinimumLength = InstitutionMinLength)]
        public string Institution { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Степен' е задължително.")]
        [StringLength(DegreeMaxLength, MinimumLength = DegreeMinLength)]
        public string Degree { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Специалност' е задължително.")]
        [StringLength(SpecialtyMaxLength, MinimumLength = SpecialtyMinLength)]
        public string Specialty { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Факултет' е задължително.")]
        [StringLength(FacultyMaxLength, MinimumLength = FacultyMinLength)]
        public string Faculty { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Начална дата' е задължително.")]
        [Display(Name = "Начална дата")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Крайна дата")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}

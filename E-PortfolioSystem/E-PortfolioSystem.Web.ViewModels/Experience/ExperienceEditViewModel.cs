using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.Experience
{
    public class ExperienceEditViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Полето 'Компания' е задължително.")]
        [StringLength(100)]
        public string Company { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Професия' е задължително.")]
        [StringLength(100)]
        public string Profession { get; set; } = null!;

        public string? Location { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Полето 'Начална дата' е задължително.")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Полето 'Сектор' е задължително.")]
        public string Sector { get; set; } = null!;
    }
}

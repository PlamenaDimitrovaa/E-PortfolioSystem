using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public string Id { get; set; } = null!;
        
        public string UserId { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Име' е задължително.")]
        [Display(Name = "Име")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Местоположение' е задължително.")]
        [Display(Name = "Местоположение")]
        public string Location { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Телефон' е задължително.")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'За мен' е задължително.")]
        [Display(Name = "За мен")]
        public string Bio { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Снимка' е задължително.")]
        [Display(Name = "Снимка")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Публичен профил")]
        public bool IsPublic { get; set; }
    }
}

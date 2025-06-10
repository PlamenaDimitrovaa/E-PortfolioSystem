using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public string Id { get; set; } = null!;
        
        public string UserId { get; set; } = null!;

        [Display(Name = "Име")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Местоположение")]
        public string Location { get; set; } = null!;

        [Display(Name = "Телефон")]
        public string Phone { get; set; } = null!;

        [Display(Name = "За мен")]
        public string Bio { get; set; } = null!;

        [Display(Name = "Снимка")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Публичен профил")]
        public bool IsPublic { get; set; }
    }
}

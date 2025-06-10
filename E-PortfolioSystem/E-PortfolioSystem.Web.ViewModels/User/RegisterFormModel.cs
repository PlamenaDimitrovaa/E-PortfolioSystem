using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.User
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = "Първо име е задължително!")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Първо име")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Фамилно име е задължително!")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Фамилно име")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Имейлът е задължителен!")]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Паролата е задължителна!")]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("Password", ErrorMessage = "Парола и потвърди парола не съвпадат.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}

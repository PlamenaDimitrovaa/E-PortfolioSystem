using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.User
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = "Полето Имейл е задължително")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Полето Парола е задължително")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}

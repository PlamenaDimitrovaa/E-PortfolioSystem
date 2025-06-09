using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.User;

namespace E_PortfolioSystem.Web.ViewModels.User
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = "Полето 'Имейл' е задължително.")]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Парола' е задължително.")]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} трябва да бъде най-малко {2} и най-много {1} символа дълга")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Потвърди парола' е задължително.")]
        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("Password", ErrorMessage = "Паролата и потвърди паролата не са еднакви!")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Първо име' е задължително.")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Фамилно име' е задължително.")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.HRContact;

namespace E_PortfolioSystem.Web.ViewModels.HRContact
{
    public class HRContactViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Полето 'Име' е задължително.")]
        [MaxLength(NameMaxLength)]
        [Display(Name = "Име")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Имейл' е задължително.")]
        [EmailAddress]
        [MaxLength(EmailMaxLength)]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Телефонен номер' е задължително.")]
        [Phone]
        [MaxLength(PhoneNumberMaxLength)]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Съобщение' е задължително.")]
        [MaxLength(MessageMaxLength)]
        [Display(Name = "Съобщение")]
        public string Message { get; set; } = null!;
    }
}

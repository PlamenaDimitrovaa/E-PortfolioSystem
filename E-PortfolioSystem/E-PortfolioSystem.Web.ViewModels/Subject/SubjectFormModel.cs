using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.Subject;

namespace E_PortfolioSystem.Web.ViewModels.Subject
{
    public class SubjectFormModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Името на предмета е задължително")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, 
            ErrorMessage = "Името трябва да е между {2} и {1} символа")]
        [Display(Name = "Име на предмета")]
        public string Name { get; set; } = null!;
    }
} 
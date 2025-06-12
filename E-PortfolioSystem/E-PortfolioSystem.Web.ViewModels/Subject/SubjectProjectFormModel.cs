using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using static E_PortfolioSystem.Common.EntityValidationConstants.Project;

namespace E_PortfolioSystem.Web.ViewModels.Subject
{
    public class SubjectProjectFormModel
    {
        public string SubjectId { get; set; } = null!;

        public string SubjectName { get; set; } = null!;

        [Required(ErrorMessage = "Полето 'Заглавие' е задължително!")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = "Заглавието трябва да е между {2} и {1} символа!")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = "Описанието трябва да е между {2} и {1} символа!")]
        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [StringLength(LinkMaxLength, ErrorMessage = "Линкът не може да е по-дълъг от {1} символа!")]
        [Display(Name = "Линк към проекта")]
        public string? Link { get; set; }

        [Display(Name = "Прикачен файл")]
        public IFormFile? AttachedFile { get; set; }
    }
} 
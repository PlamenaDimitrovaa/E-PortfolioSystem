using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.Project;

namespace E_PortfolioSystem.Web.ViewModels.Project
{
    public class ProjectEditViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string? Description { get; set; }

        [StringLength(LinkMaxLength, MinimumLength = LinkMinLength)]
        public string? Link { get; set; }

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string? ImageUrl { get; set; }

        [Display(Name = "Краен срок")]
        public DateTime? Deadline { get; set; }

        [Display(Name = "Дата на създаване")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Прикачен файл")]
        public IFormFile? File { get; set; }

        public AttachedDocumentFormModel? AttachedDocument { get; set; }

        [Display(Name = "Описание на документа")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string? DocumentDescription { get; set; }

        [Display(Name = "Тип на документа")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string? DocumentType { get; set; }
    }
}

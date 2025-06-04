using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.Project
{
    public class ProjectEditViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително.")]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? Link { get; set; }

        public string? ImageUrl { get; set; }

        [Display(Name = "Краен срок")]
        public DateTime? Deadline { get; set; }

        [Display(Name = "Дата на създаване")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Прикачен файл")]
        public IFormFile? File { get; set; }

        public AttachedDocumentFormModel? AttachedDocument { get; set; }

        [Display(Name = "Описание на документа")]
        public string? DocumentDescription { get; set; }

        [Display(Name = "Тип на документа")]
        public string? DocumentType { get; set; }
    }
}

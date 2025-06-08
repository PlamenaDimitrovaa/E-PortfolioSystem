using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.Certificate;

namespace E_PortfolioSystem.Web.ViewModels.Certificate
{
    public class CertificateEditViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Издателят е задължителен.")]
        [StringLength(IssuerMaxLength, MinimumLength = IssuerMinLength)]
        public string Issuer { get; set; } = null!;

        [Display(Name = "Дата на издаване")]
        [DataType(DataType.Date)]
        public DateTime? IssuedDate { get; set; }

        [Display(Name = "Прикачен файл")]
        public IFormFile? File { get; set; }

        public AttachedDocumentFormModel? AttachedDocument { get; set; }

        [Display(Name = "Описание на документа")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string? DocumentDescription { get; set; }

        [Display(Name = "Тип на документа")]
        public string? DocumentType { get; set; }

        [StringLength(FilePathMaxLength, MinimumLength = FilePathMinLength)]
        public string? FilePath { get; set; }

        public string? StudentId { get; set; }

        public string? AttachedDocumentId { get; set; }
    }
}

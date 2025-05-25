namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.AttachedDocument;
    public class AttachedDocument
    {
        public Guid Id { get; set; }

        public Guid? ProjectId { get; set; }

        [Required]
        [MaxLength(DocumentTypeMaxLength)]
        public string DocumentType { get; set; } = null!;

        [Required]
        [MaxLength(FileNameMaxLength)]
        public string FileName { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(FileContentMaxLength)]
        public string FileContent { get; set; } = null!;

        public DateTime? UploadDate { get; set; }

        [Required]
        [MaxLength(FileLocationMaxLength)]
        public string FileLocation { get; set; } = null!;

        public Project? Project { get; set; }
    }
}

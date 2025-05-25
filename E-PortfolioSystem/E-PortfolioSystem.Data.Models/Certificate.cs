namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Certificate;
    public class Certificate
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(IssuerMaxLength)]
        public string Issuer { get; set; } = null!;

        [MaxLength(FilePathMaxLength)]
        public string? FilePath { get; set; }

        public Guid AttachedDocumentId { get; set; }

        public DateTime? IssuedDate { get; set; }

        public Student Student { get; set; } = null!;

        public AttachedDocument AttachedDocument { get; set; } = null!;
    }
}

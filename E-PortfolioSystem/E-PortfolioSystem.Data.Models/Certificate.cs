namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Certificate
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public string? FilePath { get; set; }

        public Guid AttachedDocumentId { get; set; }

        public DateTime? IssuedDate { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public AttachedDocument AttachedDocument { get; set; } = null!;
    }
}

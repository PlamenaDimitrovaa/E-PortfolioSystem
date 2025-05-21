namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Email
    {
        [Key]
        public Guid Id { get; set; }

        public Guid FromUserId { get; set; }

        public Guid ToUserId { get; set; }

        public string Subject { get; set; } = null!;

        public string Body { get; set; } = null!;

        public DateTime? SentAt { get; set; }

        public ApplicationUser FromUser { get; set; } = null!;

        public ApplicationUser ToUser { get; set; } = null!;
    }
}

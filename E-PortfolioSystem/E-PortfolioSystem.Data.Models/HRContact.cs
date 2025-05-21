namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class HRContact
    {
        [Key]
        public Guid Id { get; set; }

        public Guid HRUserId { get; set; }

        public Guid StudentUserId { get; set; }

        public string Message { get; set; } = null!;

        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public ApplicationUser HRUser { get; set; } = null!;

        public ApplicationUser StudentUser { get; set; } = null!;
    }
}

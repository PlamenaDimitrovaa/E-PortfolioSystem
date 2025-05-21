namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Recommendation
    {
        [Key]
        public Guid Id { get; set; }

        public Guid FromUserId { get; set; }

        public Guid ToUserId { get; set; }

        public string Text { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ApplicationUser FromUser { get; set; } = null!;

        public ApplicationUser ToUser { get; set; } = null!;
    }
}

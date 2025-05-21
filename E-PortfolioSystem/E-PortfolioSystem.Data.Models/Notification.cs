namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public bool IsRead { get; set; } = false;

        public DateTime? CreatedAt { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}

namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Chat
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public string Message { get; set; } = null!;

        public DateTime? SentAt { get; set; }

        public ApplicationUser Sender { get; set; } = null!;

        public ApplicationUser Receiver { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_PortfolioSystem.Data.Models
{
    public class ChatMessage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SenderId { get; set; }

        [ForeignKey(nameof(SenderId))]
        public ApplicationUser Sender { get; set; } = null!;

        [Required]
        public Guid ReceiverId { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public ApplicationUser Receiver { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public DateTime Timestamp { get; set; }

        public bool IsRead { get; set; }
    }
}
namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Notification;
    public class Notification
    {
        public Notification()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        public bool IsRead { get; set; } = false;

        public DateTime? CreatedAt { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}

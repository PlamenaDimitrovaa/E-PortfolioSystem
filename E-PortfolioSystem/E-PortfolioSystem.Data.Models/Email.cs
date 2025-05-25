namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Email;
    public class Email
    {
        [Key]
        public Guid Id { get; set; }

        public Guid FromUserId { get; set; }

        public Guid ToUserId { get; set; }

        [Required]
        [MaxLength(SubjectMaxLength)]
        public string Subject { get; set; } = null!;

        [Required]
        [MaxLength(BodyMaxLength)]
        public string Body { get; set; } = null!;

        public DateTime? SentAt { get; set; }

        public ApplicationUser FromUser { get; set; } = null!;

        public ApplicationUser ToUser { get; set; } = null!;
    }
}

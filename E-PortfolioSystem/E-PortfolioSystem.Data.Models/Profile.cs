namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Profile;
    public class Profile
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Bio { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public bool IsPublic { get; set; } = false;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}

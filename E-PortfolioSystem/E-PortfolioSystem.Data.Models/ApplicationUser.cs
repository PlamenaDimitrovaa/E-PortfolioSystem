namespace E_PortfolioSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static E_PortfolioSystem.Common.EntityValidationConstants.User;
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Profile? Profile { get; set; }
       
    }
}

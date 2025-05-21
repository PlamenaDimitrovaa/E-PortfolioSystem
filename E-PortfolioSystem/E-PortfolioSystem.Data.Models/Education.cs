namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Education
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Institution { get; set; } = null!;

        public string Degree { get; set; } = null!;

        public string Specialty { get; set; } = null!;

        public string Faculty { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}

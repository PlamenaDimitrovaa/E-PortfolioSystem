using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static E_PortfolioSystem.Common.EntityValidationConstants.Experience;

namespace E_PortfolioSystem.Data.Models
{
    public class Experience
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ProfessionMaxLength)]
        public string Profession { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(CompanyMaxLength)]
        public string Company { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [MaxLength(SectorMaxLength)]
        public string? Sector { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;
    }
}

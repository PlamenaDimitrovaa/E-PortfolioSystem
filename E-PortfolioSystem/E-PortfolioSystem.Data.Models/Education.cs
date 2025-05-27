namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Education;
    public class Education
    {
        public Education()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        [Required]
        [MaxLength(InstitutionMaxLength)]
        public string Institution { get; set; } = null!;

        [Required]
        [MaxLength(DegreeMaxLength)]
        public string Degree { get; set; } = null!;

        [Required]
        [MaxLength(SpecialtyMaxLength)]
        public string Specialty { get; set; } = null!;

        [Required]
        [MaxLength(FacultyMaxLength)]
        public string Faculty { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Student Student { get; set; } = null!;
    }
}

namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Student;
    public class Student
    {
        public Student()
        {
            this.StudentSkills = new HashSet<StudentSkill>();
            this.Projects = new HashSet<Project>();
            this.Educations = new HashSet<Education>();
            this.Certificates = new HashSet<Certificate>();
            this.StudentSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        [MaxLength(FacultyNumberMaxLength)]
        public string FacultyNumber { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public ICollection<StudentSkill> StudentSkills { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Education> Educations { get; set; }

        public ICollection<Certificate> Certificates { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}

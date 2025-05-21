namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static E_PortfolioSystem.Common.EntityValidationConstants;

    public class Student
    {
        public Student()
        {
            this.Skills = new HashSet<Skill>();
            this.Projects = new HashSet<Project>();
            this.Educations = new HashSet<Education>();
            this.Certificates = new HashSet<Certificate>();
            this.Subjects = new HashSet<Subject>();
        }
        [Key]
        public Guid Id { get; set; }

        public bool IsActive { get; set; } = true;

        public string? FacultyNumber { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Education> Educations { get; set; }

        public ICollection<Certificate> Certificates { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}

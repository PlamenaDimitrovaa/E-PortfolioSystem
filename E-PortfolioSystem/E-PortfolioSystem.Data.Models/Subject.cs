namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Subject;
    public class Subject
    {
        public Subject()
        {
            this.Id = Guid.NewGuid();
            this.StudentSubjects = new HashSet<StudentSubject>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid? EvaluationId { get; set; }

        public Guid? ProjectId { get; set; }

        public Guid TeacherId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public bool IsAdmitted { get; set; }

        public Evaluation? Evaluation { get; set; }

        public Project? Project { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}

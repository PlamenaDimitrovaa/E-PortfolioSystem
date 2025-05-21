namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Subject
    {
        public Subject()
        {
            this.Students = new HashSet<Student>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid? EvaluationId { get; set; }

        public Guid? ProjectId { get; set; }

        public Guid TeacherId { get; set; }

        public string Name { get; set; } = null!;

        public bool IsAdmitted { get; set; }

        public Evaluation? Evaluation { get; set; }

        public Project? Project { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public ICollection<Student> Students { get; set; }
    }
}

namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Evaluation
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? ProjectId { get; set; }

        public Guid TeacherId { get; set; }

        public Guid? SubjectId { get; set; }

        public int SubjectGrade { get; set; }

        public int ProjectGrade { get; set; }

        public string Feedback { get; set; } = null!;

        public DateTime? CreatedAt { get; set; } 

        public Project? Project { get; set; }

        public ApplicationUser Teacher { get; set; } = null!;

        public Subject? Subject { get; set; }
    }
}

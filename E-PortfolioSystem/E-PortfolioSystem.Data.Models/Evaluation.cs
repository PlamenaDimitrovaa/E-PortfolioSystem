namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Evaluation;
    public class Evaluation
    {
        public Evaluation()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid? ProjectId { get; set; }

        public Guid TeacherId { get; set; }

        public Guid? SubjectId { get; set; }

        public int SubjectGrade { get; set; }

        public int ProjectGrade { get; set; }

        [Required]
        [MaxLength(FeedbackMaxLength)]
        public string Feedback { get; set; } = null!;

        [Required]
        [MaxLength(EvaluationTypeMaxLength)]
        public string EvaluationType { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public Project? Project { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public Subject? Subject { get; set; }
    }
}

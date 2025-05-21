namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid? AttachedDocumentId { get; set; }

        public Guid? EvaluationId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? Link { get; set; }

        public string? FilePath { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? CreatedAt { get; set; } 

        public bool IsApproved { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public AttachedDocument? AttachedDocument { get; set; }

        public Evaluation? Evaluation { get; set; }
    }
}

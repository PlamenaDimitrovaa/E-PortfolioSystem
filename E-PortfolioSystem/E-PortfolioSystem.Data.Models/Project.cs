namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Project;
    public class Project
    {
        public Project()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid? AttachedDocumentId { get; set; }

        public Guid? EvaluationId { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(LinkMaxLength)]
        public string? Link { get; set; }

        [MaxLength(FilePathMaxLength)]
        public string? FilePath { get; set; }

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? CreatedAt { get; set; } 

        public bool IsApproved { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public AttachedDocument? AttachedDocument { get; set; }

        public Evaluation? Evaluation { get; set; }
    }
}

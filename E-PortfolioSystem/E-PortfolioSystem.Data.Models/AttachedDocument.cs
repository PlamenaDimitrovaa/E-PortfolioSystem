namespace E_PortfolioSystem.Data.Models
{
    public class AttachedDocument
    {
        public Guid Id { get; set; }

        public Guid? ProjectId { get; set; }

        public string DocumentType { get; set; } = null!;

        public string FileName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string FileContent { get; set; } = null!;

        public DateTime? UploadDate { get; set; }

        public string FileLocation { get; set; } = null!;

        public Project? Project { get; set; }
    }
}

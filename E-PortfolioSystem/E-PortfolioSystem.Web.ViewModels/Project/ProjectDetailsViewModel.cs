using E_PortfolioSystem.Web.ViewModels.AttachedDocument;

namespace E_PortfolioSystem.Web.ViewModels.Project
{
    public class ProjectDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? Link { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? AttachedDocumentId { get; set; }

        public IEnumerable<AttachedDocumentFormModel> AttachedDocuments { get; set; } = new HashSet<AttachedDocumentFormModel>();
    }
}

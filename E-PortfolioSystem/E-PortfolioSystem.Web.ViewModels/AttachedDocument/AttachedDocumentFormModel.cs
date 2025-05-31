namespace E_PortfolioSystem.Web.ViewModels.AttachedDocument
{
    public class AttachedDocumentFormModel
    {
        public string Id { get; set; } = null!;

        public string DocumentType { get; set; } = null!;

        public string FileName { get; set; } = null!;

        public string? Description { get; set; }

        public string FileContent { get; set; } = null!;

        public DateTime? UploadDate { get; set; }

        public string FileLocation { get; set; } = null!;
    }
}

using E_PortfolioSystem.Web.ViewModels.AttachedDocument;

namespace E_PortfolioSystem.Web.ViewModels.Certificate
{
    public class CertificateDetailsViewModel
    {
        public string? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public DateTime? IssuedDate { get; set; }
        public string? FilePath { get; set; }
        public string? AttachedDocumentId { get; set; }
        public IEnumerable<AttachedDocumentFormModel> AttachedDocuments { get; set; } = new HashSet<AttachedDocumentFormModel>();
    }
}

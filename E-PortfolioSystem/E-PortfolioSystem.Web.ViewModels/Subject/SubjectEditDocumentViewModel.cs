using Microsoft.AspNetCore.Http;

namespace E_PortfolioSystem.Web.ViewModels.Subject
{
    public class SubjectEditDocumentViewModel
    {
        public Guid SubjectId { get; set; }

        public string Name { get; set; } = null!;

        public bool IsAdmitted { get; set; }

        public string TeacherFullName { get; set; } = null!;

        public string? ExistingFilePath { get; set; }

        public string? ExistingFileName { get; set; }

        public string? ExistingFileId { get; set; }

        public IFormFile? NewFile { get; set; }
    }

}

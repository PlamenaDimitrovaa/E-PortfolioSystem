using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.Subject;

namespace E_PortfolioSystem.Web.ViewModels.Subject
{
    public class SubjectEditDocumentViewModel
    {
        public Guid SubjectId { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public bool IsAdmitted { get; set; }

        public string TeacherFullName { get; set; } = null!;

        public string? ExistingFilePath { get; set; }

        public string? ExistingFileName { get; set; }

        public string? ExistingFileId { get; set; }

        public IFormFile? NewFile { get; set; }
    }

}

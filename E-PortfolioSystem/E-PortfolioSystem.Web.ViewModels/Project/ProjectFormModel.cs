using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.Project
{
    public class ProjectFormModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително.")]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? Link { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? CreatedAt { get; set; }

        public IFormFile? File { get; set; } 

        public string? DocumentType { get; set; }

        public string? DocumentDescription { get; set; }
    }
}

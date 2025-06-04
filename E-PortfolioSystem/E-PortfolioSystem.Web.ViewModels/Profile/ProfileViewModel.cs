using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Bio { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public bool IsPublic { get; set; } = false;
    }
}

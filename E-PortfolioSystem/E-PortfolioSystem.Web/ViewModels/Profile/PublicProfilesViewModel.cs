using E_PortfolioSystem.Web.ViewModels.Profile;

namespace E_PortfolioSystem.Web.ViewModels.Profile
{
    public class PublicProfilesViewModel
    {
        public IEnumerable<ProfileViewModel> Profiles { get; set; } = new List<ProfileViewModel>();
        public string? SearchTerm { get; set; }
        public string? Location { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 9;
        public int TotalProfiles { get; set; }
    }
} 
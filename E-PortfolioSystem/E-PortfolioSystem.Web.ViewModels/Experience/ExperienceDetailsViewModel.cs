namespace E_PortfolioSystem.Web.ViewModels.Experience
{
    public class ExperienceDetailsViewModel
    {
        public string? Id { get; set; }
        public string Profession { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string Sector { get; set; } = null!;
    }
}

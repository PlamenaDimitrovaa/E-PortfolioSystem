namespace E_PortfolioSystem.Web.ViewModels.Education
{
    public class EducationDetailsViewModel
    {
        public string? Id { get; set; }
        public string Institution { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public string Faculty { get; set; } = null!;
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}

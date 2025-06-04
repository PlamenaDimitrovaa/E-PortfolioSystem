namespace E_PortfolioSystem.Web.ViewModels.Education
{
    public class EducationViewModel
    {
        public string? Id { get; set; }
        public string Institution { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public string Faculty { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
    }
}

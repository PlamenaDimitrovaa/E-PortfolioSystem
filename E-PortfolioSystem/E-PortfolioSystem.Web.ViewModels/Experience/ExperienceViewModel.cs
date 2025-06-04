namespace E_PortfolioSystem.Web.ViewModels.Experience
{
    public class ExperienceViewModel
    {
        public string? Id { get; set; }
        public string Company { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
    }
}

namespace E_PortfolioSystem.Web.ViewModels.Subject
{
    public class TeacherSubjectDetailsViewModel
    {
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsAdmitted { get; set; }

        public string TeacherName { get; set; } = null!;

        public int EnrolledStudentsCount { get; set; }
    }
} 
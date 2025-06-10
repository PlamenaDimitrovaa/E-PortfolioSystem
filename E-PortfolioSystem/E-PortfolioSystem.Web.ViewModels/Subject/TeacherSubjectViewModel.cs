namespace E_PortfolioSystem.Web.ViewModels.Subject
{
    public class TeacherSubjectViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool IsAdmitted { get; set; }
        public int EnrolledStudentsCount { get; set; }
    }
} 
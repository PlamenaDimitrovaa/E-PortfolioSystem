namespace E_PortfolioSystem.Web.ViewModels.Subject
{
    public class SubjectDetailsViewModel
    {
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsAdmitted { get; set; }

        public string TeacherName { get; set; } = null!;

        public DateTime? EnrolledOn { get; set; }

        // Оценка
        public int? SubjectGrade { get; set; }

        public int? ProjectGrade { get; set; }

        public string? Feedback { get; set; }

        public string? EvaluationType { get; set; }

        public DateTime? EvaluationDate { get; set; }

        // Проект
        public string? ProjectTitle { get; set; }

        public string? ProjectDescription { get; set; }

        public string? ProjectLink { get; set; }

        public string? DocumentFilePath { get; set; }

        public string? DocumentFileName { get; set; }

        public string? DocumentId { get; set; }
    }

}

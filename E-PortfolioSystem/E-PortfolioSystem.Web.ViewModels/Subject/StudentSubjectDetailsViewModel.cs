namespace E_PortfolioSystem.Web.ViewModels.Subject
{
    public class StudentSubjectDetailsViewModel
    {
        public string StudentId { get; set; } = null!;
        
        public string StudentName { get; set; } = null!;

        public string SubjectId { get; set; } = null!;

        public string SubjectName { get; set; } = null!;

        public DateTime? EnrolledOn { get; set; }

        // Проект
        public string? ProjectTitle { get; set; }

        public string? ProjectDescription { get; set; }

        public string? ProjectLink { get; set; }

        public string? DocumentFileName { get; set; }

        public string? DocumentFilePath { get; set; }

        public string? DocumentId { get; set; }

        // Оценка
        public int? SubjectGrade { get; set; }

        public int? ProjectGrade { get; set; }

        public string? Feedback { get; set; }

        public string? EvaluationType { get; set; }

        public DateTime? EvaluationDate { get; set; }
    }
} 
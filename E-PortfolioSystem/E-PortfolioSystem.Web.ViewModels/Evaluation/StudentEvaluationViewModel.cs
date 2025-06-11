using System.ComponentModel.DataAnnotations;
using static E_PortfolioSystem.Common.EntityValidationConstants.Evaluation;

namespace E_PortfolioSystem.Web.ViewModels.Evaluation
{
    public class StudentEvaluationViewModel
    {       
        public string StudentId { get; set; } = null!;

        [Display(Name = "Име на студент")]
        [Required(ErrorMessage = "Полето 'Име на студент' е задължително!")]
        public string StudentName { get; set; } = null!;

        [Display(Name = "Факултетен номер")]
        [Required(ErrorMessage = "Полето 'Факултетен номер' е задължително!")]
        public string FacultyNumber { get; set; } = null!;

        [Display(Name = "Заглавие на проект")]
        [Required(ErrorMessage = "Полето 'Заглавие на проект' е задължително!")]
        public string? ProjectTitle { get; set; }
        public string? AttachedDocumentUrl { get; set; }

        public string? SubjectId { get; set; }

        [Display(Name = "Оценка на предмет")]
        [Range(2, 6, ErrorMessage = "Оценката трябва да бъде между 2 и 6.")]
        public int SubjectGrade { get; set; }

        [Display(Name = "Оценка на проект")]
        [Range(2, 6, ErrorMessage = "Оценката трябва да бъде между 2 и 6.")]
        public int ProjectGrade { get; set; }

        [Display(Name = "Обратна връзка")]
        [Required(ErrorMessage = "Полето 'Обратна връзка' е задължително!")]
        [MaxLength(FeedbackMaxLength)]
        public string Feedback { get; set; } = null!;

        [Display(Name = "Тип на оценяването")]
        [Required(ErrorMessage = "Полето 'Тип на оценяването' е задължително!'")]
        [MaxLength(EvaluationTypeMaxLength)]
        public string EvaluationType { get; set; } = null!;
    }

}

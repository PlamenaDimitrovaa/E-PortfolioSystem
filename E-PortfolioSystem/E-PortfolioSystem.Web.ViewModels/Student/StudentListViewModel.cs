using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Web.ViewModels.Student
{
    public class StudentListViewModel
    {
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string FacultyNumber { get; set; } = null!;

        public bool IsEnrolled { get; set; }
    }
} 
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Web.ViewModels.Student;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IStudentService
    {
        Task<string> GetStudentIdByUserIdAsync(string userId);
        string GetStudentIdByUserId(string userId);
        Task<bool> StudentExistsByUserIdAsync(string userId);
        Task<IEnumerable<StudentListViewModel>> GetAllStudentsForSubjectAsync(string subjectId);
        Task EnrollStudentInSubjectAsync(string studentId, string subjectId);
        Task RemoveStudentFromSubjectAsync(string studentId, string subjectId);
        Task<bool> IsStudentEnrolledInSubjectAsync(string studentId, string subjectId);
        Task CreateStudentAsync(Guid userId);
        Task<IEnumerable<StudentListViewModel>> GetStudentsByTeacherAsync(Guid teacherId);
    }
}

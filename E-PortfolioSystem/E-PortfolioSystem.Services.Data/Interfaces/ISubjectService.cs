using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Web.ViewModels.Subject;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectViewModel>> GetSubjectsByStudentAsync(string studentId);
        Task<SubjectDetailsViewModel?> GetSubjectDetailsAsync(Guid subjectId, Guid studentId);
        Task UpdateSubjectAttachedDocumentAsync(Guid subjectId, string fileName, string filePath);
        Task<Subject?> GetSubjectWithDocumentAsync(Guid subjectId);
    }
}

using E_PortfolioSystem.Web.ViewModels.Evaluation;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IEvaluationService
    {
        Task<StudentEvaluationViewModel> GetEvaluationFormAsync(Guid subjectId, Guid studentId);
        Task SubmitEvaluationAsync(StudentEvaluationViewModel model, Guid teacherId);
    }
}

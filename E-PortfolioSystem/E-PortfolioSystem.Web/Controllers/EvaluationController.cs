using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Services.Data.Services;
using E_PortfolioSystem.Web.Infrastructure.Extensions;
using E_PortfolioSystem.Web.ViewModels.Evaluation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_PortfolioSystem.Web.Controllers
{
    [Authorize]
    public class EvaluationController : Controller
    {
        private readonly IEvaluationService evaluationService;
        private readonly ITeacherService teacherService;

        public EvaluationController(
            IEvaluationService evaluationService,
            ITeacherService teacherService)
        {
            this.evaluationService = evaluationService;
            this.teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Evaluate(string subjectId, string studentId)
        {
            var model = await evaluationService.GetEvaluationFormAsync(Guid.Parse(subjectId), Guid.Parse(studentId));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Evaluate(StudentEvaluationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var teacherId = await teacherService.GetTeacherIdByUserIdAsync(User.GetId());
            await evaluationService.SubmitEvaluationAsync(model, Guid.Parse(teacherId));

            TempData["SuccessMessage"] = "Оценката е запазена успешно.";
            return RedirectToAction("Subjects", "TeacherSubject");
        }
    }
}

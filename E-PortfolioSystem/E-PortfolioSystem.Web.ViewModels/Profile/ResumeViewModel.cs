using E_PortfolioSystem.Web.ViewModels.Certificate;
using E_PortfolioSystem.Web.ViewModels.Education;
using E_PortfolioSystem.Web.ViewModels.Experience;
using E_PortfolioSystem.Web.ViewModels.Skill;

namespace E_PortfolioSystem.Web.ViewModels.Profile
{
    public class ResumeViewModel
    {
        public string? Id { get; set; }
        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string FacultyNumber { get; set; } = null!;
        public string? CvDownloadLink { get; set; }

        public IEnumerable<ExperienceViewModel> Experiences { get; set; } = new List<ExperienceViewModel>();
        public IEnumerable<EducationViewModel> Educations { get; set; } = new List<EducationViewModel>();
        public IEnumerable<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
        public IEnumerable<CertificateViewModel> Certificates { get; set; } = new List<CertificateViewModel>();
    }
}

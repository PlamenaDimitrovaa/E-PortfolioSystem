using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Certificate;
using E_PortfolioSystem.Web.ViewModels.Education;
using E_PortfolioSystem.Web.ViewModels.Skill;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly EPortfolioDbContext dbContext;

        public CertificateService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CertificateViewModel>> GetAllByUserIdAsync(string? id)
        {
            return await dbContext.Certificates
              .Include(x => x.Student)
              .Where(x => x.Student.UserId.ToString() == id)
              .Select(e => new CertificateViewModel
              {
                  Id = e.Id.ToString(),
                  Title = e.Title,
                  Issuer = e.Issuer,
                  IssuedDate = e.IssuedDate,
                  FilePath = e.FilePath,
                  AttachedDocumentId = e.AttachedDocumentId.ToString()
              })
              .ToListAsync();
        }

        public async Task<CertificateDetailsViewModel?> GetByIdAsync(string id)
        {
            var bgCulture = new CultureInfo("bg-BG");

            return await dbContext.Certificates
                 .Where(s => s.Id.ToString() == id)
                 .Select(s => new CertificateDetailsViewModel
                 {
                     Id = s.Id.ToString(),
                     Title = s.Title,
                     Issuer = s.Issuer,
                     IssuedDate = s.IssuedDate,
                     FilePath = s.FilePath,
                     AttachedDocumentId = s.AttachedDocumentId.ToString()
                 })
                 .FirstOrDefaultAsync();
        }
    }
}

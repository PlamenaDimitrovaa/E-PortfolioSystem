using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Education;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class EducationService : IEducationService
    {
        private readonly EPortfolioDbContext dbContext;

        public EducationService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<EducationViewModel>> GetAllByUserIdAsync(string? id)
        {
            return await dbContext.Educations
               .Include(x => x.Student)
               .Where(x => x.Student.UserId.ToString() == id)
               .Select(e => new EducationViewModel
               {
                   Id = e.Id.ToString(),
                   Institution = e.Institution,
                   Degree = e.Degree,
                   Specialty = e.Specialty,
                   Faculty = e.Faculty,
                   StartDate = e.StartDate,
                   EndDate = e.EndDate
               })
               .ToListAsync();
        }

        public async Task<EducationDetailsViewModel?> GetByIdAsync(string id)
        {
            var bgCulture = new CultureInfo("bg-BG");

            return await dbContext.Educations
                .Where(e => e.Id.ToString() == id)
                .Select(e => new EducationDetailsViewModel
                {
                    Id = e.Id.ToString(),
                    Institution = e.Institution,
                    Degree = e.Degree,
                    Specialty = e.Specialty,
                    Faculty = e.Faculty,
                    StartDate = e.StartDate.ToString("MMMM yyyy", bgCulture),
                    EndDate = e.EndDate.ToString("MMMM yyyy", bgCulture)
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EducationEditViewModel?> GetEducationForEditAsync(string id)
        {
            if (!Guid.TryParse(id, out var educationId))
            {
                return null;
            }

            var education = await dbContext.Educations
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == educationId);

            if (education == null)
            {
                return null;
            }

            return new EducationEditViewModel
            {
                Id = education.Id.ToString(),
                Institution = education.Institution,
                Degree = education.Degree,
                Specialty = education.Specialty,
                Faculty = education.Faculty,
                StartDate = education.StartDate,
                EndDate = education.EndDate == default ? (DateTime?)null : education.EndDate
            };
        }

        public async Task UpdateEducationAsync(EducationEditViewModel model)
        {
            if (!Guid.TryParse(model.Id, out var educationId))
            {
                throw new ArgumentException("Невалиден идентификатор.");
            }

            var education = await dbContext.Educations.FindAsync(educationId);

            if (education == null)
            {
                throw new InvalidOperationException("Образованието не е намерено.");
            }

            education.Institution = model.Institution;
            education.Degree = model.Degree;
            education.Specialty = model.Specialty;
            education.Faculty = model.Faculty;
            education.StartDate = model.StartDate;
            education.EndDate = model.EndDate ?? default;

            await dbContext.SaveChangesAsync();
        }
        public async Task AddEducationAsync(EducationEditViewModel model, string userId)
        {
            var student = await dbContext.Students
                .FirstOrDefaultAsync(s => s.UserId.ToString() == userId);

            if (student == null)
            {
                throw new InvalidOperationException("Не е намерен студент за този потребител.");
            }

            var education = new Education
            {
                Id = Guid.NewGuid(),
                Institution = model.Institution,
                Degree = model.Degree,
                Specialty = model.Specialty,
                Faculty = model.Faculty,
                StartDate = model.StartDate,
                EndDate = model.EndDate ?? default,
                StudentId = student.Id
            };

            await dbContext.Educations.AddAsync(education);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEducationAsync(string educationId)
        {
            var guid = Guid.Parse(educationId);

            var education = await dbContext.Educations
                .FirstOrDefaultAsync(e => e.Id == guid);

            if (education == null)
            {
                throw new InvalidOperationException("Образованието не е намерено.");
            }

            dbContext.Educations.Remove(education);
            await dbContext.SaveChangesAsync();
        }
    }
}

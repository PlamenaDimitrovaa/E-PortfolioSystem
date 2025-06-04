using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Experience;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly EPortfolioDbContext dbContext;

        public ExperienceService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ExperienceViewModel>> GetAllByUserIdAsync(string? id)
        {
            return await dbContext.Experiences
                .Include(x => x.Student)
                .Where(x => x.Student.UserId.ToString() == id)
                .Select(e => new ExperienceViewModel
                {
                    Id = e.Id.ToString(),
                    Company = e.Company,
                    Profession = e.Profession,
                    // Location = e.Location,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Description = e.Description
                })
                .ToListAsync();
        }

        public async Task<ExperienceDetailsViewModel?> GetByIdAsync(string id)
        {
            var bgCulture = new CultureInfo("bg-BG");

            return await dbContext.Experiences
           .Where(e => e.Id.ToString() == id)
           .Select(e => new ExperienceDetailsViewModel
           {
               Id = e.Id.ToString(),
               Profession = e.Profession,
               Company = e.Company,
               Description = e.Description ?? "",
               StartDate = e.StartDate.ToString("MMMM yyyy", bgCulture),
               EndDate = e.EndDate.HasValue ? e.EndDate.Value.ToString("MMMM yyyy", bgCulture) : "настояще",
               Sector = e.Sector ?? ""
           })
           .FirstOrDefaultAsync();
        }

        public async Task<ExperienceEditViewModel?> GetForEditByIdAsync(string id)
        {
            return await dbContext.Experiences
               .Where(e => e.Id.ToString() == id)
               .Select(e => new ExperienceEditViewModel
               {
                   Id = e.Id.ToString(),
                   Company = e.Company,
                   Profession = e.Profession,
                   Description = e.Description,
                   StartDate = e.StartDate,
                   EndDate = e.EndDate,
                   Sector = e.Sector ?? ""
               })
               .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(string id, ExperienceEditViewModel model)
        {
            var experience = await dbContext.Experiences.FirstOrDefaultAsync(e => e.Id.ToString() == model.Id);
            if (experience == null) return false;

            experience.Company = model.Company;
            experience.Profession = model.Profession;
            experience.Description = model.Description;
            experience.StartDate = model.StartDate;
            experience.EndDate = model.EndDate;
            experience.Sector = model.Sector;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task AddAsync(ExperienceEditViewModel model, string userId)
        {
            var student = await dbContext.Students
                .FirstOrDefaultAsync(s => s.UserId.ToString() == userId);

            if (student == null)
            {
                throw new InvalidOperationException("Студентът не е намерен");
            }

            var experience = new Experience
            {
                Id = Guid.NewGuid(),
                Company = model.Company,
                Profession = model.Profession,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Sector = model.Sector,
                StudentId = student.Id
            };

            dbContext.Experiences.Add(experience);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var experience = await dbContext.Experiences
                .FirstOrDefaultAsync(e => e.Id.ToString() == id);

            if (experience == null)
            {
                throw new InvalidOperationException("Не са намеренни данни за този опит!");
            }

            dbContext.Experiences.Remove(experience);
            await dbContext.SaveChangesAsync();
        }
    }
}

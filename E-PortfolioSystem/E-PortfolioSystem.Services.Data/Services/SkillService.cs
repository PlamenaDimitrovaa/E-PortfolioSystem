using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Skill;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class SkillService : ISkillService
    {
        private readonly EPortfolioDbContext dbContext;

        public SkillService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SkillDetailsViewModel?> GetByIdAsync(string id)
        {
            return await dbContext.StudentsSkills
                .Where(s => s.SkillId.ToString() == id)
                .Select(s => new SkillDetailsViewModel
                {
                    Id = s.SkillId.ToString(),
                    Name = s.Skill.SkillName,
                    Level = s.Skill.Level
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SkillViewModel>> GetAllByUserIdAsync(string? id)
        {
            return await dbContext.StudentsSkills
               .Include(s => s.Student)
               .Where(s => s.Student.UserId.ToString() == id)
               .Select(ss => new SkillViewModel
               {
                   Id = ss.SkillId.ToString(),
                   Name = ss.Skill.SkillName,
                   Level = ss.Skill.Level
               })
               .ToListAsync();
        }

        public async Task<SkillEditViewModel?> GetSkillForEditAsync(string id)
        {
            if (!Guid.TryParse(id, out var skillId))
            {
                return null;
            }

            var skill = await dbContext.Skills
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == skillId);

            if (skill == null)
            {
                return null;
            }

            return new SkillEditViewModel
            {
                Id = skill.Id.ToString(),
                Name = skill.SkillName,
                Level = skill.Level
            };
        }

        public async Task UpdateSkillAsync(SkillEditViewModel model)
        {
            if (!Guid.TryParse(model.Id, out var skillId))
            {
                throw new ArgumentException("Невалиден идентификатор на умение.");
            }

            var skill = await dbContext.Skills.FindAsync(skillId);

            if (skill == null)
            {
                throw new InvalidOperationException("Умението не е намерено.");
            }

            skill.SkillName = model.Name;
            skill.Level = model.Level;

            await dbContext.SaveChangesAsync();
        }

        public async Task<Guid> AddAsync(SkillEditViewModel model, Guid userId, string studentId)
        {
            var skill = new E_PortfolioSystem.Data.Models.Skill
            {
                SkillName = model.Name,
                Level = model.Level
            };

            await dbContext.Skills.AddAsync(skill);

            var studentSkill = new StudentSkill
            {
                SkillId = skill.Id,
                StudentId = Guid.Parse(studentId),
                Skill = skill
            };

            await dbContext.StudentsSkills.AddAsync(studentSkill);
            await dbContext.SaveChangesAsync();

            return skill.Id;
        }

        public async Task DeleteAsync(string id, string studentId)
        {
            var studentSkill = await dbContext.StudentsSkills
             .FirstOrDefaultAsync(ss => ss.SkillId.ToString() == id && ss.StudentId.ToString() == studentId);

            if (studentSkill != null)
            {
                dbContext.StudentsSkills.Remove(studentSkill);

                bool isSkillUsedElsewhere = await dbContext.StudentsSkills
                    .AnyAsync(ss => ss.SkillId.ToString() == id && ss.StudentId.ToString() != studentId);

                if (!isSkillUsedElsewhere)
                {
                    var skill = await dbContext.Skills.FindAsync(Guid.Parse(id));
                    if (skill != null)
                    {
                        dbContext.Skills.Remove(skill);
                    }
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}

using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.HRContact;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class HRContactService : IHRContactService
    {
        private readonly EPortfolioDbContext dbContext;

        public HRContactService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(HRContactViewModel model, Guid hrUserId, Guid studentUserId)
        {
            var contact = new HRContact
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Message = model.Message,
                SentAt = DateTime.UtcNow,
                HRUserId = hrUserId,
                StudentUserId = studentUserId
            };

            await dbContext.HRContacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HRContactViewModel>> GetAllByHRUserIdAsync(Guid hrUserId)
        {
            return await dbContext.HRContacts
                .Where(h => h.HRUserId == hrUserId)
                .OrderByDescending(h => h.SentAt)
                .Select(h => new HRContactViewModel
                {
                    Id = h.Id.ToString(),
                    Name = h.Name,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Message = h.Message,
                    SentAt = h.SentAt,
                    ToUserId = h.StudentUserId.ToString()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<HRContactViewModel>> GetAllByStudentUserIdAsync(Guid studentUserId)
        {
            return await dbContext.HRContacts
                .Where(h => h.StudentUserId == studentUserId)
                .OrderByDescending(h => h.SentAt)
                .Select(h => new HRContactViewModel
                {
                    Id = h.Id.ToString(),
                    Name = h.Name,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Message = h.Message,
                    SentAt = h.SentAt,
                    ToUserId = h.StudentUserId.ToString()
                })
                .ToListAsync();
        }

        public async Task<HRContactViewModel?> GetByIdAsync(Guid id)
        {
            var contact = await dbContext.HRContacts
                .FirstOrDefaultAsync(h => h.Id == id);

            if (contact == null)
            {
                return null;
            }

            return new HRContactViewModel
            {
                Id = contact.Id.ToString(),
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Message = contact.Message,
                SentAt = contact.SentAt,
                ToUserId = contact.StudentUserId.ToString()
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var contact = await dbContext.HRContacts
                .FirstOrDefaultAsync(h => h.Id == id);

            if (contact != null)
            {
                dbContext.HRContacts.Remove(contact);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

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
    }
}

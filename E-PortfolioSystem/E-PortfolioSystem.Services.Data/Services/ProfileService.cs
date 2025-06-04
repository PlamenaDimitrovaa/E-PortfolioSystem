using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.Profile;
using Microsoft.EntityFrameworkCore;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class ProfileService : IProfileService
    {
        private readonly EPortfolioDbContext dbContext;

        public ProfileService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProfileViewModel> GetProfileByUserIdAsync(string? id)
        {
            return await dbContext.Profiles
            .Where(p => p.UserId.ToString() == id)
            .Select(p => new ProfileViewModel
            {
                Id = p.Id.ToString(),
                UserId = p.UserId.ToString(),
                FullName = p.FullName,
                Location = p.Location,
                Phone = p.Phone,
                Bio = p.Bio,
                ImageUrl = p.ImageUrl,
                IsPublic = p.IsPublic
            })
            .FirstOrDefaultAsync();
        }
    }
}

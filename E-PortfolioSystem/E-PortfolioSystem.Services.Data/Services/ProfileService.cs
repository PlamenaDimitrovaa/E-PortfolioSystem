using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
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
            var profile = await dbContext.Profiles
                .FirstOrDefaultAsync(p => p.UserId.ToString() == id);

            if (profile == null)
            {
                return null;
            }

            return new ProfileViewModel
            {
                Id = profile.Id.ToString(),
                UserId = profile.UserId.ToString(),
                FullName = profile.FullName,
                Location = profile.Location,
                Phone = profile.Phone,
                Bio = profile.Bio,
                ImageUrl = profile.ImageUrl,
                IsPublic = profile.IsPublic
            };
        }

        public async Task CreateProfileAsync(Guid userId, string fullName)
        {
            var profile = new Profile
            {
                UserId = userId,
                FullName = fullName,
                Phone = string.Empty,
                Bio = string.Empty,
                Location = string.Empty,
                ImageUrl = "/assets/default-profile.jpg",
                IsPublic = false
            };

            await dbContext.Profiles.AddAsync(profile);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByUserIdAsync(Guid userId)
        {
            return await dbContext.Profiles.AnyAsync(p => p.UserId == userId);
        }

        public async Task UpdateProfileAsync(Guid userId, string phone, string bio, string location, string imageUrl, bool isPublic)
        {
            var profile = await dbContext.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
            
            if (profile != null)
            {
                profile.Phone = phone;
                profile.Bio = bio;
                profile.Location = location;
                profile.ImageUrl = imageUrl;
                profile.IsPublic = isPublic;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}

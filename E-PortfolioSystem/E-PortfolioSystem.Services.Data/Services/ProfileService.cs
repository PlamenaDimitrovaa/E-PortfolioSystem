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
            var student = await dbContext.Students.FirstOrDefaultAsync(s => s.UserId.ToString() == id);

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
                ImageUrl = "~/assets/profile.png",
                IsPublic = false
            };

            await dbContext.Profiles.AddAsync(profile);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByUserIdAsync(Guid userId)
        {
            return await dbContext.Profiles.AnyAsync(p => p.UserId == userId);
        }

        public async Task UpdateProfileAsync(Guid userId, string fullName, string phone, string bio, string location, string imageUrl, bool isPublic)
        {
            var profile = await dbContext.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
            
            if (profile != null)
            {
                profile.FullName = fullName;
                profile.Phone = phone;
                profile.Bio = bio;
                profile.Location = location;
                profile.ImageUrl = imageUrl;
                profile.IsPublic = isPublic;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProfileViewModel>> GetAllPublicProfilesAsync(string? searchTerm = null, string? location = null, int page = 1, int pageSize = 9, string? excludeUserId = null)
        {
            var query = dbContext.Profiles
                .Where(p => p.IsPublic);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(p =>
                    p.FullName.ToLower().Contains(searchTerm) ||
                    p.Bio.ToLower().Contains(searchTerm));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                location = location.ToLower();
                query = query.Where(p => p.Location.ToLower().Contains(location));
            }

            if (!string.IsNullOrEmpty(excludeUserId))
            {
                query = query.Where(p => p.UserId.ToString() != excludeUserId);
            }

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProfileViewModel
                {
                    Id = p.Id.ToString(),
                    UserId = p.UserId.ToString(),
                    FullName = p.FullName,
                    Phone = p.Phone,
                    Bio = p.Bio,
                    Location = p.Location,
                    ImageUrl = p.ImageUrl,
                    IsPublic = p.IsPublic
                })
                .ToListAsync();
        }

        public async Task<int> GetTotalPublicProfilesCountAsync(string? searchTerm = null, string? location = null)
        {
            var query = dbContext.Profiles
                .Where(p => p.IsPublic);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(p => 
                    p.FullName.ToLower().Contains(searchTerm) || 
                    p.Bio.ToLower().Contains(searchTerm));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                location = location.ToLower();
                query = query.Where(p => p.Location.ToLower().Contains(location));
            }

            return await query.CountAsync();
        }
    }
}

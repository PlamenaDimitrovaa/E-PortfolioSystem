namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("Test");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("Testov");

            var hasher = new PasswordHasher<ApplicationUser>();

            var users = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id = Guid.Parse("a1d7b600-4459-4f80-92d0-1b3e9f3b7234"),
                UserName = "student1@example.com",
                NormalizedUserName = "STUDENT1@EXAMPLE.COM",
                Email = "student1@example.com",
                NormalizedEmail = "STUDENT1@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "11111111-1111-1111-1111-111111111111",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
            new ApplicationUser
            {
                Id = Guid.Parse("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128"),
                UserName = "student2@example.com",
                NormalizedUserName = "STUDENT2@EXAMPLE.COM",
                Email = "student2@example.com",
                NormalizedEmail = "STUDENT2@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "22222222-2222-2222-2222-222222222222",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
            new ApplicationUser
            {
                Id = Guid.Parse("5c9225c4-f837-4e1e-8f33-b2c13b184951"),
                UserName = "student3@example.com",
                NormalizedUserName = "STUDENT3@EXAMPLE.COM",
                Email = "student3@example.com",
                NormalizedEmail = "STUDENT3@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "33333333-3333-3333-3333-333333333333",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
            new ApplicationUser
            {
                Id = Guid.Parse("ed49c00b-2026-41e0-a97c-9f4f7e74cb79"),
                UserName = "student4@example.com",
                NormalizedUserName = "STUDENT4@EXAMPLE.COM",
                Email = "student4@example.com",
                NormalizedEmail = "STUDENT4@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "44444444-4444-4444-4444-444444444444",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
            new ApplicationUser
            {
                Id = Guid.Parse("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6"),
                UserName = "student5@example.com",
                NormalizedUserName = "STUDENT5@EXAMPLE.COM",
                Email = "student5@example.com",
                NormalizedEmail = "STUDENT5@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "55555555-5555-5555-5555-555555555555",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
            new ApplicationUser
            {
                Id = Guid.Parse("61ba8c0d-1c34-4b68-8881-218f70632a09"),
                UserName = "teacher1@example.com",
                NormalizedUserName = "TEACHER1@EXAMPLE.COM",
                Email = "teacher1@example.com",
                NormalizedEmail = "TEACHER1@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "66666666-6666-6666-6666-666666666666",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
             new ApplicationUser
            {
                Id = Guid.Parse("13c96c70-f547-41f3-91e6-84b38e92e994"),
                UserName = "teacher2@example.com",
                NormalizedUserName = "TEACHER2@EXAMPLE.COM",
                Email = "teacher2@example.com",
                NormalizedEmail = "TEACHER2@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "77777777-7777-7777-7777-777777777777",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
            new ApplicationUser
            {
                Id = Guid.Parse("dcbcf227-4302-4743-8c99-e216bc1a6aef"),
                UserName = "teacher3@example.com",
                NormalizedUserName = "TEACHER3@EXAMPLE.COM",
                Email = "teacher3@example.com",
                NormalizedEmail = "TEACHER3@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "88888888-8888-8888-8888-888888888888",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
            new ApplicationUser
            {
                Id = Guid.Parse("94b8a56e-4a0f-4f39-8e83-1ad38c207d30"),
                UserName = "teacher4@example.com",
                NormalizedUserName = "TEACHER4@EXAMPLE.COM",
                Email = "teacher4@example.com",
                NormalizedEmail = "TEACHER4@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "99999999-9999-9999-9999-999999999999",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            },
            new ApplicationUser
            {
                Id = Guid.Parse("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5"),
                UserName = "teacher5@example.com",
                NormalizedUserName = "TEACHER5@EXAMPLE.COM",
                Email = "teacher5@example.com",
                NormalizedEmail = "TEACHER5@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 2
            }
        };

            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, "Password@123");
            }

           // builder.HasData(users);
        }
    }
}
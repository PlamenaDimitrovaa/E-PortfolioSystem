namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class HRContactEntityConfiguration : IEntityTypeConfiguration<HRContact>
    {
        public void Configure(EntityTypeBuilder<HRContact> builder)
        {
            builder
                .HasKey(h => h.Id);

            builder
                .HasOne(h => h.HRUser)
                .WithMany()
                .HasForeignKey(h => h.HRUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.StudentUser)
                .WithMany()
                .HasForeignKey(h => h.StudentUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(this.GenerateHRContacts());
        }

        private HRContact[] GenerateHRContacts()
        {
            return new[]
           {
                new HRContact
                {
                    Id = Guid.Parse("62f1a280-b56a-4d47-888e-1f5b8c2cf332"),
                    HRUserId = Guid.Parse("2c4b13cf-1676-49c6-9cf1-5c7a321cbf3a"), // HR 1
                    StudentUserId = Guid.Parse("a1d7b600-4459-4f80-92d0-1b3e9f3b7234"), // Student 1
                    Message = "Здравейте Иван, впечатлени сме от профила Ви и бихме искали да обсъдим възможност за стаж.",
                    SentAt = DateTime.UtcNow
                },
                new HRContact
                {
                    Id = Guid.Parse("8d4a23f9-c3fb-48a0-8f9f-d8036c9c59fb"),
                    HRUserId = Guid.Parse("3d93db49-59ba-4225-889f-bdc6d4eecdf6"), // HR 2
                    StudentUserId = Guid.Parse("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128"), // Student 2
                    Message = "Мария, Вашите умения в уеб разработката отговарят на нашите търсения за младши програмист.",
                    SentAt = DateTime.UtcNow.AddDays(-1)
                },
                new HRContact
                {
                    Id = Guid.Parse("dd287aa9-678f-41e7-9e7b-1db9c59b15ce"),
                    HRUserId = Guid.Parse("fc47c38c-cf3f-48a6-97d6-d9fc24401d85"), // HR 3
                    StudentUserId = Guid.Parse("5c9225c4-f837-4e1e-8f33-b2c13b184951"), // Student 3
                    Message = "Николай, интересува ли Ви позиция за UX стажант в нашата компания?",
                    SentAt = DateTime.UtcNow.AddDays(-2)
                },
                new HRContact
                {
                    Id = Guid.Parse("bb8e1eeb-16d3-4c6c-9b73-5aabdc2a5cf5"),
                    HRUserId = Guid.Parse("3c2e2a17-cc5a-4986-b1f6-7b7a719da3b9"), // HR 4
                    StudentUserId = Guid.Parse("ed49c00b-2026-41e0-a97c-9f4f7e74cb79"), // Student 4
                    Message = "Елена, бихме искали да Ви поканим на интервю за креативна дизайнерска позиция.",
                    SentAt = DateTime.UtcNow.AddDays(-3)
                },
                new HRContact
                {
                    Id = Guid.Parse("e5bfb33a-8e6b-4ef6-8617-4721d06cb865"),
                    HRUserId = Guid.Parse("f15b6c7f-dab3-4db5-a9d4-e61cd295a2a5"), // HR 5
                    StudentUserId = Guid.Parse("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6"), // Student 5
                    Message = "Георги, имаме отворена позиция за backend разработчик и бихме искали да се свържем с Вас.",
                    SentAt = DateTime.UtcNow.AddDays(-4)
                }
            };
        }
    }
}

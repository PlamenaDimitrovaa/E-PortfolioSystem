namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class RecommendationEntityConfiguration : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .HasOne(r => r.FromUser)
                .WithMany()
                .HasForeignKey(r => r.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(r => r.ToUser)
                .WithMany()
                .HasForeignKey(r => r.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateRecommendations());
        }

        private Recommendation[] GenerateRecommendations()
        {
            return new[]
           {
                new Recommendation
                {
                    Id = Guid.Parse("f0c502be-1144-4042-b607-06c3b8d527ff"),
                    FromUserId = Guid.Parse("61BA8C0D-1C34-4B68-8881-218F70632A09"),
                    ToUserId = Guid.Parse("a1d7b600-4459-4f80-92d0-1b3e9f3b7234"),
                    Text = "Иван демонстрира изключителни умения за анализ на данни и работа в екип.",
                    CreatedAt = new DateTime(2024, 5, 17, 16, 0, 0, DateTimeKind.Utc)
                },
                new Recommendation
                {
                    Id = Guid.Parse("22939c60-f1ef-41aa-9c92-c74cd440a0e0"),
                    FromUserId = Guid.Parse("94B8A56E-4A0F-4F39-8E83-1AD38C207D30"),
                    ToUserId = Guid.Parse("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128"),
                    Text = "Мария има силно портфолио и отлични комуникационни умения.",
                    CreatedAt = new DateTime(2024, 5, 20, 10, 30, 0, DateTimeKind.Utc)
                },
                new Recommendation
                {
                    Id = Guid.Parse("31c0a993-4307-46ef-a057-24ae70990c96"),
                    FromUserId = Guid.Parse("94B8A56E-4A0F-4F39-8E83-1AD38C207D30"),
                    ToUserId = Guid.Parse("ed49c00b-2026-41e0-a97c-9f4f7e74cb79"),
                    Text = "Дизайнерското мислене и UI/UX уменията на Елена са впечатляващи.",
                    CreatedAt = new DateTime(2024, 5, 24, 14, 0, 0, DateTimeKind.Utc)
                },
                new Recommendation
                {
                    Id = Guid.Parse("9fd67d3a-2b35-472e-bfac-46ffec0e65bc"),
                    FromUserId = Guid.Parse("9CB5E4E7-8A6D-4F35-B3A2-973E1EC764F5"),
                    ToUserId = Guid.Parse("5c9225c4-f837-4e1e-8f33-b2c13b184951"),
                    Text = "Николай показа дълбоко разбиране на принципите на UX дизайна.",
                    CreatedAt = new DateTime(2024, 5, 22, 11, 0, 0, DateTimeKind.Utc)
                },
                new Recommendation
                {
                    Id = Guid.Parse("d1604d93-dcfd-4460-9426-c92a86bbf683"),
                    FromUserId = Guid.Parse("9CB5E4E7-8A6D-4F35-B3A2-973E1EC764F5"),
                    ToUserId = Guid.Parse("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6"),
                    Text = "Георги е силно аналитичен и ориентиран към детайлите.",
                    CreatedAt = new DateTime(2024, 5, 25, 9, 0, 0, DateTimeKind.Utc)
                }
            };
        }
    }
}

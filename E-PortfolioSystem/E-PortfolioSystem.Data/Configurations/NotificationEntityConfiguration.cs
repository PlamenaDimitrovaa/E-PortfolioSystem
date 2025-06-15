namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class NotificationEntityConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId);

            builder.HasData(this.GenerateNotifications());
        }

        private Notification[] GenerateNotifications()
        {
            return new[]
             {
                new Notification
                {
                    Id = Guid.Parse("c1f7896e-a28c-4c8c-baf8-037c3b08ac91"),
                    UserId = Guid.Parse("a1d7b600-4459-4f80-92d0-1b3e9f3b7234"),
                    Title = "Добре дошъл!",
                    Content = "Добре дошъл в системата за електронно портфолио!",
                    IsRead = false,
                    CreatedAt = new DateTime(2024, 5, 1, 10, 0, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("e2a403f3-f8fc-4657-bf5f-bf9838e31d87"),
                    UserId = Guid.Parse("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128"),
                    Title = "Добавен проект",
                    Content = "Успешно добави своя първи проект.",
                    IsRead = false,
                    CreatedAt = new DateTime(2024, 5, 2, 11, 30, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("1bff2e77-9dc3-4930-b49e-2ff8d645a00f"),
                    UserId = Guid.Parse("5c9225c4-f837-4e1e-8f33-b2c13b184951"),
                    Title = "Нова оценка",
                    Content = "Имаш нова оценка по курс.",
                    IsRead = false,
                    CreatedAt = new DateTime(2024, 5, 3, 14, 15, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("6a6179c6-8934-4ee0-a79f-df0887601f24"),
                    UserId = Guid.Parse("ed49c00b-2026-41e0-a97c-9f4f7e74cb79"),
                    Title = "Обратна връзка",
                    Content = "Получена е обратна връзка по твой проект.",
                    IsRead = true,
                    CreatedAt = new DateTime(2024, 5, 4, 9, 45, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("a95e2b8f-8d9f-45de-87b1-bce51c53d5d1"),
                    UserId = Guid.Parse("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6"),
                    Title = "Качен документ",
                    Content = "Успешно качи нов документ.",
                    IsRead = false,
                    CreatedAt = new DateTime(2024, 5, 5, 16, 0, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("d9e9f616-b276-48e3-8ff9-9648a649b282"),
                    UserId = Guid.Parse("61ba8c0d-1c34-4b68-8881-218f70632a09"),
                    Title = "Нов студент",
                    Content = "Нов студент се е регистрирал.",
                    IsRead = false,
                    CreatedAt = new DateTime(2024, 5, 6, 8, 20, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("7902f7de-b6a3-4d94-acc4-7d03cda13361"),
                    UserId = Guid.Parse("13c96c70-f547-41f3-91e6-84b38e92e994"),
                    Title = "Проект за преглед",
                    Content = "Имате нов проект за преглед.",
                    IsRead = false,
                    CreatedAt = new DateTime(2024, 5, 7, 13, 10, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("e83df197-33b6-441f-b9c3-3b7c7c1a0173"),
                    UserId = Guid.Parse("dcbcf227-4302-4743-8c99-e216bc1a6aef"),
                    Title = "Документ от студент",
                    Content = "Студент е качил нов документ.",
                    IsRead = false,
                    CreatedAt = new DateTime(2024, 5, 8, 15, 40, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("bb78d857-0179-4e5a-bf7c-06b5a40a7ff0"),
                    UserId = Guid.Parse("94b8a56e-4a0f-4f39-8e83-1ad38c207d30"),
                    Title = "Обратна връзка изпратена",
                    Content = "Успешно изпрати обратна връзка на студент.",
                    IsRead = true,
                    CreatedAt = new DateTime(2024, 5, 9, 10, 5, 0, DateTimeKind.Utc)
                },
                new Notification
                {
                    Id = Guid.Parse("95c8c566-3dc3-41dc-a73e-172a564be502"),
                    UserId = Guid.Parse("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5"),
                    Title = "Оценка завършена",
                    Content = "Завърши оценка по проект.",
                    IsRead = false,
                    CreatedAt = new DateTime(2024, 5, 10, 12, 30, 0, DateTimeKind.Utc)
                }
            };
        }
    }
}

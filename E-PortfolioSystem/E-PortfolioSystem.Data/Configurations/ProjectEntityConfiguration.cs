namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder.HasData(this.GenerateProjects());
        }

        private Project[] GenerateProjects()
        {
            return new[]
         {
                new Project
                {
                    Id = Guid.Parse("122bf74b-69b4-4b2b-81b3-f203cd889a11"),
                    UserId = Guid.Parse("B4E0DCF9-B1CB-45A1-93D6-D0DBB130F128"), // Student1 UserId
                    AttachedDocumentId = Guid.Parse("60e7e4d1-7d77-4d3d-9792-bd02dcad8ef1"),
                    EvaluationId = Guid.Parse("777c1952-01ed-4cce-88c0-6b2a0610d351"),
                    Title = "AI Чатбот асистент",
                    Description = "Чатбот, който помага на потребителите с автоматизирани отговори с помощта на AI.",
                    Link = "https://github.com/student1/ai-chatbot",
                    FilePath = "/projects/student1/chatbot.zip",
                    ImageUrl = "https://mma.prnewswire.com/media/2218114/Screenshots_AI_Chat.jpg",
                    Deadline = new DateTime(2025, 12, 31, 23, 59, 59, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2025, 1, 1, 9, 0, 0, DateTimeKind.Utc),
                    IsApproved = true
                },
                new Project
                {
                    Id = Guid.Parse("2f5b887d-3c46-45e1-b826-3dbbe8570dd8"),
                    UserId = Guid.Parse("ED49C00B-2026-41E0-A97C-9F4F7E74CB79"), // Student2 UserId
                    AttachedDocumentId = Guid.Parse("f3f2163a-24cb-43d0-a3e5-c0c34c18cc2c"),
                    EvaluationId = Guid.Parse("6ad69f6e-7c4c-4a5b-aeb6-bb43d193bce5"),
                    Title = "Платформа за онлайн търговия",
                    Description = "Базиран на ASP.NET уеб магазин с потребителска регистрация и количка.",
                    Link = "https://student2-shop.example.com",
                    FilePath = "/projects/student2/ecommerce.zip",
                    ImageUrl = "https://techvify-software.com/wp-content/uploads/2023/08/5-best-free-ecommerce-flatform.png",
                    Deadline = new DateTime(2025, 11, 30, 18, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2025, 2, 1, 10, 30, 0, DateTimeKind.Utc),
                    IsApproved = true
                },
                new Project
                {
                    Id = Guid.Parse("1c83cafd-c4f7-4eb1-809c-2703df8c29c5"),
                    UserId = Guid.Parse("5C9225C4-F837-4E1E-8F33-B2C13B184951"), // Student3 UserId
                    AttachedDocumentId = Guid.Parse("9df4d32b-76d2-4c7f-8e42-ec4f7baf34cb"),
                    EvaluationId = Guid.Parse("f9d41ad3-6f3e-4861-82de-d0a0df68b798"),
                    Title = "Уебсайт за портфолио",
                    Description = "Лично портфолио, създадено с React и Tailwind CSS.",
                    Link = "https://student3.dev",
                    FilePath = "/projects/student3/portfolio.zip",
                    ImageUrl = "https://i.ytimg.com/vi/Dtb3DdSvYRY/maxresdefault.jpg",
                    Deadline = new DateTime(2025, 10, 15, 20, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2025, 3, 1, 14, 0, 0, DateTimeKind.Utc),
                    IsApproved = false
                },
                new Project
                {
                    Id = Guid.Parse("c2e6dffd-19d4-4b80-bf3b-d5a69fae59b0"),
                    UserId = Guid.Parse("7F25FD3E-1719-43A5-8FBE-BAD7F62BE7A6"), // Student4 UserId
                    AttachedDocumentId = Guid.Parse("bebf91e9-90aa-4b65-b0ff-1fa91f4c83e4"),
                    EvaluationId = Guid.Parse("8f74e0e4-3b4a-496a-a6d7-219d0108fc34"),
                    Title = "Проследяване на мобилни приложения",
                    Description = "Приложение за Android, което проследява навиците на потребителите.",
                    Link = "https://play.google.com/store/apps/details?id=tracker.student4",
                    FilePath = "/projects/student4/tracker.apk",
                    ImageUrl = "https://images.ctfassets.net/jicu8fwm4fvs/49r9KDrN6wNy5S8a1XJOZZ/e69da8fb1fd10239c8a85e016400809b/16-mobile-tracker-thumbnail.png",
                    Deadline = new DateTime(2025, 12, 1, 12, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2025, 4, 1, 8, 0, 0, DateTimeKind.Utc),
                    IsApproved = true
                },
                new Project
                {
                    Id = Guid.Parse("b79cb4a7-0ab0-4a7c-b86a-8b35c46a74fd"),
                    UserId = Guid.Parse("A1D7B600-4459-4F80-92D0-1B3E9F3B7234"), // Student5 UserId
                    AttachedDocumentId = Guid.Parse("d42e5cf4-e694-42e8-b388-34e529f383ab"),
                    EvaluationId = Guid.Parse("c025b27d-74a4-419f-b61f-64f7ab94a0b5"),
                    Title = "Оптимизатор на SQL заявки",
                    Description = "Инструмент, който анализира и подобрява производителността на SQL.",
                    Link = "https://student5-sqlopt.example.com",
                    FilePath = "/projects/student5/sqloptimizer.zip",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTgrwj1FJlzRTO3h10-jZWPm3fsoGwvstz7QA&s",
                    Deadline = new DateTime(2025, 11, 15, 15, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2025, 4, 15, 16, 0, 0, DateTimeKind.Utc),
                    IsApproved = false
                }
            };
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForSubjectsEvaluationsProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "CreatedAt", "EvaluationType", "Feedback", "ProjectGrade", "ProjectId", "SubjectGrade", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("6ad69f6e-7c4c-4a5b-aeb6-bb43d193bce5"), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Финална", "Добре структурирано и с изчистен код", 5, new Guid("2f5b887d-3c46-45e1-b826-3dbbe8570dd8"), 5, new Guid("31bc0e6b-4f14-4212-b67e-9b61f3e58f73"), new Guid("be0087cd-b86f-47b0-bde4-1632f8fd632e") },
                    { new Guid("777c1952-01ed-4cce-88c0-6b2a0610d351"), new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Финална", "Отлична имплементация на концепции от Изкуствения интелект с изчистен потребителски интерфейс.", 5, new Guid("122bf74b-69b4-4b2b-81b3-f203cd889a11"), 6, new Guid("ec6942eb-7f50-4f4b-8011-891c5051eb32"), new Guid("99f1710c-97b3-4bd3-8171-e0dc986d313d") },
                    { new Guid("8f74e0e4-3b4a-496a-a6d7-219d0108fc34"), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Защита", "Креативна идея, трябват подобрения в UX.", 5, new Guid("c2e6dffd-19d4-4b80-bf3b-d5a69fae59b0"), 4, new Guid("7f489f70-911e-40a4-8b79-1d6c3315c8cb"), new Guid("b34045a7-94f6-4e32-a7e7-f36eb9a387e3") },
                    { new Guid("c025b27d-74a4-419f-b61f-64f7ab94a0b5"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Финална", "Прекрасна работа!", 6, new Guid("b79cb4a7-0ab0-4a7c-b86a-8b35c46a74fd"), 6, new Guid("c4c2079d-1ed1-4f5f-8e36-4b03cc6e71da"), new Guid("abdcf0bb-76b4-4a4d-a369-e2de9a6d4d65") },
                    { new Guid("f9d41ad3-6f3e-4861-82de-d0a0df68b798"), new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Защита", "Красив потребителски интерфейс, логически грешки, трябва да се поработи върху идеята.", 4, new Guid("1c83cafd-c4f7-4eb1-809c-2703df8c29c5"), 6, new Guid("8e3c0f29-c432-45c9-9e32-7a7a1df28523"), new Guid("c7f6b928-bbd3-4ae9-bad5-91e417b59a98") }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AttachedDocumentId", "CreatedAt", "Deadline", "Description", "EvaluationId", "FilePath", "ImageUrl", "IsApproved", "Link", "StudentId", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("122bf74b-69b4-4b2b-81b3-f203cd889a11"), new Guid("60e7e4d1-7d77-4d3d-9792-bd02dcad8ef1"), new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 12, 31, 23, 59, 59, 0, DateTimeKind.Utc), "Чатбот, който помага на потребителите с автоматизирани отговори с помощта на AI.", new Guid("777c1952-01ed-4cce-88c0-6b2a0610d351"), "/projects/student1/chatbot.zip", "https://mma.prnewswire.com/media/2218114/Screenshots_AI_Chat.jpg", true, "https://github.com/student1/ai-chatbot", null, "AI Чатбот асистент", new Guid("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128") },
                    { new Guid("1c83cafd-c4f7-4eb1-809c-2703df8c29c5"), new Guid("9df4d32b-76d2-4c7f-8e42-ec4f7baf34cb"), new DateTime(2025, 3, 1, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 15, 20, 0, 0, 0, DateTimeKind.Utc), "Лично портфолио, създадено с React и Tailwind CSS.", new Guid("f9d41ad3-6f3e-4861-82de-d0a0df68b798"), "/projects/student3/portfolio.zip", "https://i.ytimg.com/vi/Dtb3DdSvYRY/maxresdefault.jpg", false, "https://student3.dev", null, "Уебсайт за портфолио", new Guid("5c9225c4-f837-4e1e-8f33-b2c13b184951") },
                    { new Guid("2f5b887d-3c46-45e1-b826-3dbbe8570dd8"), new Guid("f3f2163a-24cb-43d0-a3e5-c0c34c18cc2c"), new DateTime(2025, 2, 1, 10, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 30, 18, 0, 0, 0, DateTimeKind.Utc), "Базиран на ASP.NET уеб магазин с потребителска регистрация и количка.", new Guid("6ad69f6e-7c4c-4a5b-aeb6-bb43d193bce5"), "/projects/student2/ecommerce.zip", "https://techvify-software.com/wp-content/uploads/2023/08/5-best-free-ecommerce-flatform.png", true, "https://student2-shop.example.com", null, "Платформа за онлайн търговия", new Guid("ed49c00b-2026-41e0-a97c-9f4f7e74cb79") },
                    { new Guid("b79cb4a7-0ab0-4a7c-b86a-8b35c46a74fd"), new Guid("d42e5cf4-e694-42e8-b388-34e529f383ab"), new DateTime(2025, 4, 15, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 15, 15, 0, 0, 0, DateTimeKind.Utc), "Инструмент, който анализира и подобрява производителността на SQL.", new Guid("c025b27d-74a4-419f-b61f-64f7ab94a0b5"), "/projects/student5/sqloptimizer.zip", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTgrwj1FJlzRTO3h10-jZWPm3fsoGwvstz7QA&s", false, "https://student5-sqlopt.example.com", null, "Оптимизатор на SQL заявки", new Guid("a1d7b600-4459-4f80-92d0-1b3e9f3b7234") },
                    { new Guid("c2e6dffd-19d4-4b80-bf3b-d5a69fae59b0"), new Guid("bebf91e9-90aa-4b65-b0ff-1fa91f4c83e4"), new DateTime(2025, 4, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 12, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Приложение за Android, което проследява навиците на потребителите.", new Guid("8f74e0e4-3b4a-496a-a6d7-219d0108fc34"), "/projects/student4/tracker.apk", "https://images.ctfassets.net/jicu8fwm4fvs/49r9KDrN6wNy5S8a1XJOZZ/e69da8fb1fd10239c8a85e016400809b/16-mobile-tracker-thumbnail.png", true, "https://play.google.com/store/apps/details?id=tracker.student4", null, "Проследяване на мобилни приложения", new Guid("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6") }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "EvaluationId", "IsAdmitted", "Name", "ProjectId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("31bc0e6b-4f14-4212-b67e-9b61f3e58f73"), new Guid("6ad69f6e-7c4c-4a5b-aeb6-bb43d193bce5"), true, "Системи за онлайн търговия", new Guid("2f5b887d-3c46-45e1-b826-3dbbe8570dd8"), new Guid("be0087cd-b86f-47b0-bde4-1632f8fd632e") },
                    { new Guid("7f489f70-911e-40a4-8b79-1d6c3315c8cb"), new Guid("8f74e0e4-3b4a-496a-a6d7-219d0108fc34"), true, "Творчески технологии", new Guid("c2e6dffd-19d4-4b80-bf3b-d5a69fae59b0"), new Guid("b34045a7-94f6-4e32-a7e7-f36eb9a387e3") },
                    { new Guid("8e3c0f29-c432-45c9-9e32-7a7a1df28523"), new Guid("f9d41ad3-6f3e-4861-82de-d0a0df68b798"), true, "Дизайн на потребителския интерфейс", new Guid("1c83cafd-c4f7-4eb1-809c-2703df8c29c5"), new Guid("c7f6b928-bbd3-4ae9-bad5-91e417b59a98") },
                    { new Guid("c4c2079d-1ed1-4f5f-8e36-4b03cc6e71da"), new Guid("c025b27d-74a4-419f-b61f-64f7ab94a0b5"), true, "Оптимизация на алгоритми", new Guid("b79cb4a7-0ab0-4a7c-b86a-8b35c46a74fd"), new Guid("abdcf0bb-76b4-4a4d-a369-e2de9a6d4d65") },
                    { new Guid("ec6942eb-7f50-4f4b-8011-891c5051eb32"), new Guid("777c1952-01ed-4cce-88c0-6b2a0610d351"), true, "Изкуствен интелект", new Guid("122bf74b-69b4-4b2b-81b3-f203cd889a11"), new Guid("99f1710c-97b3-4bd3-8171-e0dc986d313d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("31bc0e6b-4f14-4212-b67e-9b61f3e58f73"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7f489f70-911e-40a4-8b79-1d6c3315c8cb"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8e3c0f29-c432-45c9-9e32-7a7a1df28523"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("c4c2079d-1ed1-4f5f-8e36-4b03cc6e71da"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ec6942eb-7f50-4f4b-8011-891c5051eb32"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("122bf74b-69b4-4b2b-81b3-f203cd889a11"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("1c83cafd-c4f7-4eb1-809c-2703df8c29c5"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("2f5b887d-3c46-45e1-b826-3dbbe8570dd8"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b79cb4a7-0ab0-4a7c-b86a-8b35c46a74fd"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("c2e6dffd-19d4-4b80-bf3b-d5a69fae59b0"));

            migrationBuilder.DeleteData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: new Guid("6ad69f6e-7c4c-4a5b-aeb6-bb43d193bce5"));

            migrationBuilder.DeleteData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: new Guid("777c1952-01ed-4cce-88c0-6b2a0610d351"));

            migrationBuilder.DeleteData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: new Guid("8f74e0e4-3b4a-496a-a6d7-219d0108fc34"));

            migrationBuilder.DeleteData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: new Guid("c025b27d-74a4-419f-b61f-64f7ab94a0b5"));

            migrationBuilder.DeleteData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: new Guid("f9d41ad3-6f3e-4861-82de-d0a0df68b798"));
        }
    }
}

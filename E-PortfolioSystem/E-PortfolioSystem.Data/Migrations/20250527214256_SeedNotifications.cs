using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "IsRead", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1bff2e77-9dc3-4930-b49e-2ff8d645a00f"), "Имаш нова оценка по курс.", new DateTime(2024, 5, 3, 14, 15, 0, 0, DateTimeKind.Utc), false, "Нова оценка", new Guid("5c9225c4-f837-4e1e-8f33-b2c13b184951") },
                    { new Guid("6a6179c6-8934-4ee0-a79f-df0887601f24"), "Получена е обратна връзка по твой проект.", new DateTime(2024, 5, 4, 9, 45, 0, 0, DateTimeKind.Utc), true, "Обратна връзка", new Guid("ed49c00b-2026-41e0-a97c-9f4f7e74cb79") },
                    { new Guid("7902f7de-b6a3-4d94-acc4-7d03cda13361"), "Имате нов проект за преглед.", new DateTime(2024, 5, 7, 13, 10, 0, 0, DateTimeKind.Utc), false, "Проект за преглед", new Guid("13c96c70-f547-41f3-91e6-84b38e92e994") },
                    { new Guid("95c8c566-3dc3-41dc-a73e-172a564be502"), "Завърши оценка по проект.", new DateTime(2024, 5, 10, 12, 30, 0, 0, DateTimeKind.Utc), false, "Оценка завършена", new Guid("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5") },
                    { new Guid("a95e2b8f-8d9f-45de-87b1-bce51c53d5d1"), "Успешно качи нов документ.", new DateTime(2024, 5, 5, 16, 0, 0, 0, DateTimeKind.Utc), false, "Качен документ", new Guid("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6") },
                    { new Guid("bb78d857-0179-4e5a-bf7c-06b5a40a7ff0"), "Успешно изпрати обратна връзка на студент.", new DateTime(2024, 5, 9, 10, 5, 0, 0, DateTimeKind.Utc), true, "Обратна връзка изпратена", new Guid("94b8a56e-4a0f-4f39-8e83-1ad38c207d30") },
                    { new Guid("c1f7896e-a28c-4c8c-baf8-037c3b08ac91"), "Добре дошъл в системата за електронно портфолио!", new DateTime(2024, 5, 1, 10, 0, 0, 0, DateTimeKind.Utc), false, "Добре дошъл!", new Guid("a1d7b600-4459-4f80-92d0-1b3e9f3b7234") },
                    { new Guid("d9e9f616-b276-48e3-8ff9-9648a649b282"), "Нов студент се е регистрирал.", new DateTime(2024, 5, 6, 8, 20, 0, 0, DateTimeKind.Utc), false, "Нов студент", new Guid("61ba8c0d-1c34-4b68-8881-218f70632a09") },
                    { new Guid("e2a403f3-f8fc-4657-bf5f-bf9838e31d87"), "Успешно добави своя първи проект.", new DateTime(2024, 5, 2, 11, 30, 0, 0, DateTimeKind.Utc), false, "Добавен проект", new Guid("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128") },
                    { new Guid("e83df197-33b6-441f-b9c3-3b7c7c1a0173"), "Студент е качил нов документ.", new DateTime(2024, 5, 8, 15, 40, 0, 0, DateTimeKind.Utc), false, "Документ от студент", new Guid("dcbcf227-4302-4743-8c99-e216bc1a6aef") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("1bff2e77-9dc3-4930-b49e-2ff8d645a00f"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("6a6179c6-8934-4ee0-a79f-df0887601f24"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("7902f7de-b6a3-4d94-acc4-7d03cda13361"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("95c8c566-3dc3-41dc-a73e-172a564be502"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("a95e2b8f-8d9f-45de-87b1-bce51c53d5d1"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("bb78d857-0179-4e5a-bf7c-06b5a40a7ff0"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("c1f7896e-a28c-4c8c-baf8-037c3b08ac91"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("d9e9f616-b276-48e3-8ff9-9648a649b282"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e2a403f3-f8fc-4657-bf5f-bf9838e31d87"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e83df197-33b6-441f-b9c3-3b7c7c1a0173"));
        }
    }
}

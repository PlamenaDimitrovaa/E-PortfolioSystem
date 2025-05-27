using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedRecommendations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recommendations",
                columns: new[] { "Id", "CreatedAt", "FromUserId", "Text", "ToUserId" },
                values: new object[,]
                {
                    { new Guid("22939c60-f1ef-41aa-9c92-c74cd440a0e0"), new DateTime(2024, 5, 20, 10, 30, 0, 0, DateTimeKind.Utc), new Guid("94b8a56e-4a0f-4f39-8e83-1ad38c207d30"), "Мария има силно портфолио и отлични комуникационни умения.", new Guid("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128") },
                    { new Guid("31c0a993-4307-46ef-a057-24ae70990c96"), new DateTime(2024, 5, 24, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("94b8a56e-4a0f-4f39-8e83-1ad38c207d30"), "Дизайнерското мислене и UI/UX уменията на Елена са впечатляващи.", new Guid("ed49c00b-2026-41e0-a97c-9f4f7e74cb79") },
                    { new Guid("9fd67d3a-2b35-472e-bfac-46ffec0e65bc"), new DateTime(2024, 5, 22, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5"), "Николай показа дълбоко разбиране на принципите на UX дизайна.", new Guid("5c9225c4-f837-4e1e-8f33-b2c13b184951") },
                    { new Guid("d1604d93-dcfd-4460-9426-c92a86bbf683"), new DateTime(2024, 5, 25, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5"), "Георги е силно аналитичен и ориентиран към детайлите.", new Guid("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6") },
                    { new Guid("f0c502be-1144-4042-b607-06c3b8d527ff"), new DateTime(2024, 5, 17, 16, 0, 0, 0, DateTimeKind.Utc), new Guid("61ba8c0d-1c34-4b68-8881-218f70632a09"), "Иван демонстрира изключителни умения за анализ на данни и работа в екип.", new Guid("a1d7b600-4459-4f80-92d0-1b3e9f3b7234") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: new Guid("22939c60-f1ef-41aa-9c92-c74cd440a0e0"));

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: new Guid("31c0a993-4307-46ef-a057-24ae70990c96"));

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: new Guid("9fd67d3a-2b35-472e-bfac-46ffec0e65bc"));

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: new Guid("d1604d93-dcfd-4460-9426-c92a86bbf683"));

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: new Guid("f0c502be-1144-4042-b607-06c3b8d527ff"));
        }
    }
}

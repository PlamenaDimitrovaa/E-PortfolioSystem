using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FacultyNumber", "IsActive", "UserId" },
                values: new object[,]
                {
                    { new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"), "FN2023001", true, new Guid("a1d7b600-4459-4f80-92d0-1b3e9f3b7234") },
                    { new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202"), "FN2023002", true, new Guid("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128") },
                    { new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e"), "FN2023004", true, new Guid("ed49c00b-2026-41e0-a97c-9f4f7e74cb79") },
                    { new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920"), "FN2023003", true, new Guid("5c9225c4-f837-4e1e-8f33-b2c13b184951") },
                    { new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"), "FN2023005", true, new Guid("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"));
        }
    }
}

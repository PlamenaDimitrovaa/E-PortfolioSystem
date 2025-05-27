using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedEducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Degree", "EndDate", "Faculty", "Institution", "Specialty", "StartDate", "StudentId" },
                values: new object[,]
                {
                    { new Guid("1e527d02-9797-4e9f-8bfc-b62412754427"), "Бакалавър", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Департамент по информатика", "Нов български университет", "Информационни технологии", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920") },
                    { new Guid("347aeb9f-b7d3-4b84-ae50-ea154d94b1cb"), "Бакалавър", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Факултет по математика и информатика", "Пловдивски университет", "Приложна компютърна лингвистика", new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67") },
                    { new Guid("712de13f-8c38-4dd5-aac0-82c10b3f3a21"), "Бакалавър", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Факултет по автоматизация и изчислителна техника", "Технически университет - Варна", "Автоматизация, информационна и управляваща техника", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e") },
                    { new Guid("9eabfcee-2f79-4b8e-9537-92e7c655b9c7"), "Бакалавър", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Факултет по математика и информатика", "Софийски университет", "Софтуерно инженерство", new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202") },
                    { new Guid("d74b56a7-f444-42ed-b5d5-f5c416d5a80f"), "Бакалавър", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Факултет по компютърни науки", "Технически университет - София", "Компютърни системи и технологии", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: new Guid("1e527d02-9797-4e9f-8bfc-b62412754427"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: new Guid("347aeb9f-b7d3-4b84-ae50-ea154d94b1cb"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: new Guid("712de13f-8c38-4dd5-aac0-82c10b3f3a21"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: new Guid("9eabfcee-2f79-4b8e-9537-92e7c655b9c7"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: new Guid("d74b56a7-f444-42ed-b5d5-f5c416d5a80f"));
        }
    }
}

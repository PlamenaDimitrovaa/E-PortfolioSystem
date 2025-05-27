using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedStudentSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentsSubjects",
                columns: new[] { "StudentId", "SubjectId", "EnrolledOn" },
                values: new object[,]
                {
                    { new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"), new Guid("ec6942eb-7f50-4f4b-8011-891c5051eb32"), new DateTime(2024, 9, 15, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202"), new Guid("31bc0e6b-4f14-4212-b67e-9b61f3e58f73"), new DateTime(2024, 9, 16, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e"), new Guid("7f489f70-911e-40a4-8b79-1d6c3315c8cb"), new DateTime(2024, 9, 18, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920"), new Guid("8e3c0f29-c432-45c9-9e32-7a7a1df28523"), new DateTime(2024, 9, 17, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"), new Guid("c4c2079d-1ed1-4f5f-8e36-4b03cc6e71da"), new DateTime(2024, 9, 19, 12, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"), new Guid("ec6942eb-7f50-4f4b-8011-891c5051eb32") });

            migrationBuilder.DeleteData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202"), new Guid("31bc0e6b-4f14-4212-b67e-9b61f3e58f73") });

            migrationBuilder.DeleteData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e"), new Guid("7f489f70-911e-40a4-8b79-1d6c3315c8cb") });

            migrationBuilder.DeleteData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920"), new Guid("8e3c0f29-c432-45c9-9e32-7a7a1df28523") });

            migrationBuilder.DeleteData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"), new Guid("c4c2079d-1ed1-4f5f-8e36-4b03cc6e71da") });
        }
    }
}

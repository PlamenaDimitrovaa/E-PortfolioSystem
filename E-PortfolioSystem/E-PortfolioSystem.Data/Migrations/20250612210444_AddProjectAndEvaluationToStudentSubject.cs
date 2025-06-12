using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectAndEvaluationToStudentSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EvaluationId",
                table: "StudentsSubjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "StudentsSubjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"), new Guid("ec6942eb-7f50-4f4b-8011-891c5051eb32") },
                columns: new[] { "EvaluationId", "ProjectId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202"), new Guid("31bc0e6b-4f14-4212-b67e-9b61f3e58f73") },
                columns: new[] { "EvaluationId", "ProjectId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e"), new Guid("7f489f70-911e-40a4-8b79-1d6c3315c8cb") },
                columns: new[] { "EvaluationId", "ProjectId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920"), new Guid("8e3c0f29-c432-45c9-9e32-7a7a1df28523") },
                columns: new[] { "EvaluationId", "ProjectId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "StudentsSubjects",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"), new Guid("c4c2079d-1ed1-4f5f-8e36-4b03cc6e71da") },
                columns: new[] { "EvaluationId", "ProjectId" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "StudentsSubjects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "StudentsSubjects");
        }
    }
}

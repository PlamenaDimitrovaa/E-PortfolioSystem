using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedStudentsSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentsSkills",
                columns: new[] { "SkillId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("3a991cc1-f84e-466e-9962-70c50c634b76"), new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591") },
                    { new Guid("4ff51c1f-90a4-41de-b165-001de306d93e"), new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591") },
                    { new Guid("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a"), new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591") },
                    { new Guid("3a991cc1-f84e-466e-9962-70c50c634b76"), new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202") },
                    { new Guid("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a"), new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202") },
                    { new Guid("4ff51c1f-90a4-41de-b165-001de306d93e"), new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e") },
                    { new Guid("54cc88d3-f8a4-4716-bd3b-b92c915e3df6"), new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e") },
                    { new Guid("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4"), new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e") },
                    { new Guid("54cc88d3-f8a4-4716-bd3b-b92c915e3df6"), new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920") },
                    { new Guid("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4"), new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("3a991cc1-f84e-466e-9962-70c50c634b76"), new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("4ff51c1f-90a4-41de-b165-001de306d93e"), new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a"), new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("3a991cc1-f84e-466e-9962-70c50c634b76"), new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a"), new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("4ff51c1f-90a4-41de-b165-001de306d93e"), new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("54cc88d3-f8a4-4716-bd3b-b92c915e3df6"), new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4"), new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("54cc88d3-f8a4-4716-bd3b-b92c915e3df6"), new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920") });

            migrationBuilder.DeleteData(
                table: "StudentsSkills",
                keyColumns: new[] { "SkillId", "StudentId" },
                keyValues: new object[] { new Guid("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4"), new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67") });
        }
    }
}

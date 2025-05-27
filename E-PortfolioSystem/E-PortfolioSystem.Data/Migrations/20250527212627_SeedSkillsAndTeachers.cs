using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSkillsAndTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Level", "SkillName" },
                values: new object[,]
                {
                    { new Guid("3a991cc1-f84e-466e-9962-70c50c634b76"), "Напреднал", "C# Програмиране" },
                    { new Guid("4ff51c1f-90a4-41de-b165-001de306d93e"), "Междинен", "JavaScript" },
                    { new Guid("54cc88d3-f8a4-4716-bd3b-b92c915e3df6"), "Напреднал", "HTML & CSS" },
                    { new Guid("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4"), "Междинен", "SQL" },
                    { new Guid("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a"), "Начинаещ", "ASP.NET Core" }
                });

            //migrationBuilder.InsertData(
            //    table: "Teachers",
            //    columns: new[] { "Id", "UserId" },
            //    values: new object[,]
            //    {
            //        { new Guid("99f1710c-97b3-4bd3-8171-e0dc986d313d"), new Guid("61ba8c0d-1c34-4b68-8881-218f70632a09") },
            //        { new Guid("abdcf0bb-76b4-4a4d-a369-e2de9a6d4d65"), new Guid("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5") },
            //        { new Guid("b34045a7-94f6-4e32-a7e7-f36eb9a387e3"), new Guid("94b8a56e-4a0f-4f39-8e83-1ad38c207d30") },
            //        { new Guid("be0087cd-b86f-47b0-bde4-1632f8fd632e"), new Guid("13c96c70-f547-41f3-91e6-84b38e92e994") },
            //        { new Guid("c7f6b928-bbd3-4ae9-bad5-91e417b59a98"), new Guid("dcbcf227-4302-4743-8c99-e216bc1a6aef") }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3a991cc1-f84e-466e-9962-70c50c634b76"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("4ff51c1f-90a4-41de-b165-001de306d93e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("54cc88d3-f8a4-4716-bd3b-b92c915e3df6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("99f1710c-97b3-4bd3-8171-e0dc986d313d"));

            //migrationBuilder.DeleteData(
            //    table: "Teachers",
            //    keyColumn: "Id",
            //    keyValue: new Guid("abdcf0bb-76b4-4a4d-a369-e2de9a6d4d65"));

            //migrationBuilder.DeleteData(
            //    table: "Teachers",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b34045a7-94f6-4e32-a7e7-f36eb9a387e3"));

            //migrationBuilder.DeleteData(
            //    table: "Teachers",
            //    keyColumn: "Id",
            //    keyValue: new Guid("be0087cd-b86f-47b0-bde4-1632f8fd632e"));

            //migrationBuilder.DeleteData(
            //    table: "Teachers",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c7f6b928-bbd3-4ae9-bad5-91e417b59a98"));
        }
    }
}

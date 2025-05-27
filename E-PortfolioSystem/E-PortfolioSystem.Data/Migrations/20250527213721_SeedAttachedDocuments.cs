using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAttachedDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AttachedDocuments",
                columns: new[] { "Id", "Description", "DocumentType", "FileContent", "FileLocation", "FileName", "ProjectId", "UploadDate" },
                values: new object[,]
                {
                    { new Guid("60e7e4d1-7d77-4d3d-9792-bd02dcad8ef1"), "Сертификат за Основи на C#", "PDF", "base64stringcontent1", "/files/student1/certificate1.pdf", "Certificate_Student1.pdf", null, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("9df4d32b-76d2-4c7f-8e42-ec4f7baf34cb"), "Сертификат за уеб програмиране", "PDF", "base64stringcontent3", "/files/student3/certificate3.pdf", "Certificate_Student3.pdf", null, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("bebf91e9-90aa-4b65-b0ff-1fa91f4c83e4"), "Сертификат за Python", "PDF", "base64stringcontent4", "/files/student4/certificate4.pdf", "Certificate_Student4.pdf", null, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d42e5cf4-e694-42e8-b388-34e529f383ab"), "Сертификат за SQL", "PDF", "base64stringcontent5", "/files/student5/certificate5.pdf", "Certificate_Student5.pdf", null, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f3f2163a-24cb-43d0-a3e5-c0c34c18cc2c"), "Сертификат за Java Advanced", "DOCX", "base64stringcontent2", "/files/student2/certificate2.docx", "Certificate_Student2.docx", null, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttachedDocuments",
                keyColumn: "Id",
                keyValue: new Guid("60e7e4d1-7d77-4d3d-9792-bd02dcad8ef1"));

            migrationBuilder.DeleteData(
                table: "AttachedDocuments",
                keyColumn: "Id",
                keyValue: new Guid("9df4d32b-76d2-4c7f-8e42-ec4f7baf34cb"));

            migrationBuilder.DeleteData(
                table: "AttachedDocuments",
                keyColumn: "Id",
                keyValue: new Guid("bebf91e9-90aa-4b65-b0ff-1fa91f4c83e4"));

            migrationBuilder.DeleteData(
                table: "AttachedDocuments",
                keyColumn: "Id",
                keyValue: new Guid("d42e5cf4-e694-42e8-b388-34e529f383ab"));

            migrationBuilder.DeleteData(
                table: "AttachedDocuments",
                keyColumn: "Id",
                keyValue: new Guid("f3f2163a-24cb-43d0-a3e5-c0c34c18cc2c"));
        }
    }
}

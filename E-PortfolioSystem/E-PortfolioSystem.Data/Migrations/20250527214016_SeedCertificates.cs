using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCertificates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "AttachedDocumentId", "FilePath", "IssuedDate", "Issuer", "StudentId", "Title" },
                values: new object[,]
                {
                    { new Guid("19a5d055-1714-456a-aee7-e1fd195aeb2d"), new Guid("9df4d32b-76d2-4c7f-8e42-ec4f7baf34cb"), "https://img.freepik.com/free-psd/sign-that-says-certificate-approval-approval-it_69286-538.jpg", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Udemy", new Guid("7f3cd066-6f98-43e2-bff1-17972e62f202"), "ASP.NET Core Уеб програмиране" },
                    { new Guid("2cf9b2e4-b22f-4639-9d6b-631d97a37d3f"), new Guid("d42e5cf4-e694-42e8-b388-34e529f383ab"), "https://img.freepik.com/free-vector/abstract-colorful-design-certificates_23-2148886971.jpg", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Oracle", new Guid("b61b3a88-78d9-4044-a166-2b8754ec255e"), "Системи базиданни" },
                    { new Guid("a0d6d83d-54b7-4fd9-bbe2-d46014a148af"), new Guid("60e7e4d1-7d77-4d3d-9792-bd02dcad8ef1"), "https://img.freepik.com/free-psd/elegant-certificate-template-with-golden-details_69286-460.jpg", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Microsoft", new Guid("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"), "Основи на C#" },
                    { new Guid("d2077f92-22dc-4065-a318-7cb9a3ec59e0"), new Guid("f3f2163a-24cb-43d0-a3e5-c0c34c18cc2c"), "https://img.freepik.com/free-vector/geometric-minimalist-business-certificates_23-2148896559.jpg", new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "freeCodeCamp", new Guid("cb3c4c29-7a2b-4c98-91de-57b28f35b920"), "JavaScript напреднал" },
                    { new Guid("e9578f87-d5b2-4c0a-b676-1ff7e7cdba3d"), new Guid("bebf91e9-90aa-4b65-b0ff-1fa91f4c83e4"), "https://img.freepik.com/premium-vector/certificate_733271-100.jpg", new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Coursera", new Guid("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"), "Основи на Machine Learning" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("19a5d055-1714-456a-aee7-e1fd195aeb2d"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("2cf9b2e4-b22f-4639-9d6b-631d97a37d3f"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("a0d6d83d-54b7-4fd9-bbe2-d46014a148af"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("d2077f92-22dc-4065-a318-7cb9a3ec59e0"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("e9578f87-d5b2-4c0a-b676-1ff7e7cdba3d"));
        }
    }
}

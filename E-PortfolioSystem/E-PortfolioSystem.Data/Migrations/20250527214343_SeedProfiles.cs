using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "FullName", "ImageUrl", "IsPublic", "Location", "Phone", "UserId" },
                values: new object[,]
                {
                    { new Guid("20ed78c4-2599-4b1a-b70d-ea5ae9c2e4f0"), "Специалист по изкуствен интелект и машинно обучение.", "Проф. д-р Николай Костов", "https://img.freepik.com/free-photo/portrait-smiling-handsome-man_23-2149022623.jpg", true, "Пловдив, България", "+359888112202", new Guid("13c96c70-f547-41f3-91e6-84b38e92e994") },
                    { new Guid("54b6c9cc-3f49-45fd-b372-e473202f1245"), "Интересува се от уеб технологии и преподаване на HTML/CSS.", "Гл. ас. Мария Николова", "https://img.freepik.com/free-photo/beautiful-woman-smiling-outdoors_23-2148733309.jpg", false, "Варна, България", "+359888112203", new Guid("dcbcf227-4302-4743-8c99-e216bc1a6aef") },
                    { new Guid("8dbdcf2c-d43e-43df-9682-5de5975eeb83"), "UX ентусиаст с любов към дизайна.", "Николай Стоянов", "https://img.freepik.com/free-photo/portrait-smiling-young-man_1268-21877.jpg", false, "Варна, България", "+359881234563", new Guid("5c9225c4-f837-4e1e-8f33-b2c13b184951") },
                    { new Guid("8f1c86f5-169b-4dc1-9bd3-dbe7b4b3d7e5"), "Преподавател по бази данни и SQL оптимизация.", "Доц. д-р Анна Иванова", "https://img.freepik.com/free-photo/business-woman-smiling_23-2148152017.jpg", true, "София, България", "+359888112201", new Guid("61ba8c0d-1c34-4b68-8881-218f70632a09") },
                    { new Guid("933fd617-3243-4c91-b8c3-4a04041be3f9"), "Преподава компютърни мрежи и сигурност в интернет.", "Доц. д-р Стефан Георгиев", "https://img.freepik.com/free-photo/happy-man-holding-tablet_23-2149370873.jpg", true, "Русе, България", "+359888112204", new Guid("94b8a56e-4a0f-4f39-8e83-1ad38c207d30") },
                    { new Guid("d0fa45c9-70ed-4eb2-9725-c8d962cd91a2"), "Млад преподавател с интереси в областта на Java и C#.", "Ас. Георги Христов", "https://img.freepik.com/free-photo/portrait-young-man_23-2148401316.jpg", false, "Благоевград, България", "+359888112205", new Guid("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5") },
                    { new Guid("d4dfb944-f91c-4e94-83ad-41df2a9bb9c7"), "Интересува се от оптимизация и алгоритми.", "Георги Колев", "https://img.freepik.com/free-photo/front-view-man-posing_23-2148364843.jpg", false, "Русе, България", "+359881234565", new Guid("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6") },
                    { new Guid("e1a1a935-4e1e-421f-bfc3-d97843f34ea1"), "Интересува се от изкуствен интелект", "Иван Петров", "https://img.freepik.com/free-photo/close-up-smiling-boy-with-sportswear-dawn_23-2147562116.jpg", true, "София, България", "+359881234561", new Guid("a1d7b600-4459-4f80-92d0-1b3e9f3b7234") },
                    { new Guid("f4e8b0d2-d3b9-4a35-89f9-f661ea768112"), "Уеб програмист, интересува се от разработка на онлайн магазини.", "Мария Георгиева", "https://img.freepik.com/free-photo/pretty-girl-with-nice-smile_23-2147611501.jpg", true, "Пловдив, България", "+359881234562", new Guid("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128") },
                    { new Guid("fe419a14-e74e-4c6b-930e-dbd2b514f49a"), "Креативна, с интерест към технологии и изкуство.", "Елена Димитрова", "https://img.freepik.com/free-psd/close-up-kid-expression-portrait_23-2150193262.jpg", true, "Бургас, България", "+359881234564", new Guid("ed49c00b-2026-41e0-a97c-9f4f7e74cb79") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("20ed78c4-2599-4b1a-b70d-ea5ae9c2e4f0"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("54b6c9cc-3f49-45fd-b372-e473202f1245"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdcf2c-d43e-43df-9682-5de5975eeb83"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("8f1c86f5-169b-4dc1-9bd3-dbe7b4b3d7e5"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("933fd617-3243-4c91-b8c3-4a04041be3f9"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d0fa45c9-70ed-4eb2-9725-c8d962cd91a2"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d4dfb944-f91c-4e94-83ad-41df2a9bb9c7"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("e1a1a935-4e1e-421f-bfc3-d97843f34ea1"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("f4e8b0d2-d3b9-4a35-89f9-f661ea768112"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("fe419a14-e74e-4c6b-930e-dbd2b514f49a"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class HRContactIdAddedToNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HRContactId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("1bff2e77-9dc3-4930-b49e-2ff8d645a00f"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("6a6179c6-8934-4ee0-a79f-df0887601f24"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("7902f7de-b6a3-4d94-acc4-7d03cda13361"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("95c8c566-3dc3-41dc-a73e-172a564be502"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("a95e2b8f-8d9f-45de-87b1-bce51c53d5d1"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("bb78d857-0179-4e5a-bf7c-06b5a40a7ff0"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("c1f7896e-a28c-4c8c-baf8-037c3b08ac91"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("d9e9f616-b276-48e3-8ff9-9648a649b282"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e2a403f3-f8fc-4657-bf5f-bf9838e31d87"),
                column: "HRContactId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e83df197-33b6-441f-b9c3-3b7c7c1a0173"),
                column: "HRContactId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_HRContactId",
                table: "Notifications",
                column: "HRContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_HRContacts_HRContactId",
                table: "Notifications",
                column: "HRContactId",
                principalTable: "HRContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_HRContacts_HRContactId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_HRContactId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "HRContactId",
                table: "Notifications");
        }
    }
}

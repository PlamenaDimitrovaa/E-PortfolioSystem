using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_PortfolioSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class EvaluationTableTeacherChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_AspNetUsers_TeacherId",
                table: "Evaluations");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Teachers_TeacherId",
                table: "Evaluations",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Teachers_TeacherId",
                table: "Evaluations");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_AspNetUsers_TeacherId",
                table: "Evaluations",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

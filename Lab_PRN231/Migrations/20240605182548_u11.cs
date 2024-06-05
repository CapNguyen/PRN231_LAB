using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_PRN231.Migrations
{
    public partial class u11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_TeacherId1",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TeacherId1",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TeacherId1",
                table: "Schedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId1",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherId1",
                table: "Schedules",
                column: "TeacherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_TeacherId1",
                table: "Schedules",
                column: "TeacherId1",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}

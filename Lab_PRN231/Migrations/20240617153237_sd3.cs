using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_PRN231.Migrations
{
    public partial class sd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CourseId", "Date", "Slot", "TeacherId" },
                values: new object[,]
                {
                    { 5, 1, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 6, 2, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 7, 3, new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 8, 4, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "StudentSchedules",
                columns: new[] { "ScheduleId", "StudentId", "Status" },
                values: new object[,]
                {
                    { 5, 1, 2 },
                    { 6, 1, 1 },
                    { 7, 1, 2 },
                    { 8, 1, 0 },
                    { 5, 2, 2 },
                    { 6, 2, 2 },
                    { 7, 2, 2 },
                    { 8, 2, 0 },
                    { 5, 3, 2 },
                    { 6, 3, 2 },
                    { 7, 3, 1 },
                    { 8, 3, 0 }
                });
        }
    }
}

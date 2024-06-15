using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_PRN231.Migrations
{
    public partial class sd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "StudentSchedules",
                columns: new[] { "ScheduleId", "StudentId", "Status" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 1 },
                    { 3, 1, 2 },
                    { 4, 1, 2 },
                    { 5, 1, 2 },
                    { 6, 1, 1 },
                    { 7, 1, 2 },
                    { 8, 1, 0 },
                    { 1, 2, 2 },
                    { 2, 2, 2 },
                    { 3, 2, 2 },
                    { 4, 2, 2 },
                    { 5, 2, 2 },
                    { 6, 2, 2 },
                    { 7, 2, 2 },
                    { 8, 2, 0 },
                    { 1, 3, 2 },
                    { 2, 3, 2 },
                    { 3, 3, 1 },
                    { 4, 3, 2 },
                    { 5, 3, 2 },
                    { 6, 3, 2 },
                    { 7, 3, 1 },
                    { 8, 3, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 4, 1 });

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
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 4, 2 });

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
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "StudentSchedules",
                keyColumns: new[] { "ScheduleId", "StudentId" },
                keyValues: new object[] { 4, 3 });

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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_PRN231.Migrations
{
    public partial class u3 : Migration
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
                    { 1, 2, 2 },
                    { 2, 2, 2 },
                    { 3, 2, 2 },
                    { 4, 2, 2 },
                    { 1, 3, 2 },
                    { 2, 3, 2 },
                    { 3, 3, 1 },
                    { 4, 3, 2 }
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
        }
    }
}

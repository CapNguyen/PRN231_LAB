using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_PRN231.Migrations
{
    public partial class u1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentCourses");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StudentSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TimeSlot",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "EndDate", "StartDate", "SubjectCode", "TimeSlot" },
                values: new object[,]
                {
                    { 1, "SE1705-NET", null, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "P20" },
                    { 2, "SE1705-NET", null, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "P63" },
                    { 3, "SE1705-NET", null, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "P42" },
                    { 4, "EL1701", null, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "P36" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CourseId", "Date", "Slot", "TeacherId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, null, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 3, null, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 4, null, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CourseId", "Gender", "Name", "StudentCode" },
                values: new object[,]
                {
                    { 1, null, true, "Nguyen Minh Hieu", "HE171547" },
                    { 2, null, true, "Vu Minh Hieu", "HE172039" },
                    { 3, null, false, "Nguyen Minh Duy", "HE172040" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Code", "Name", "NumberOfSlot" },
                values: new object[,]
                {
                    { "EXE201", "Experiential Entrepreneurship", 16 },
                    { "MLN111", "Philosophy of Marxism – Leninism", 12 },
                    { "PRM392", "Mobile Programming", 20 },
                    { "PRN231", "Building Cross-Platform Back-End Application With .NET", 22 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, false, "Le Phuong Chi" },
                    { 2, false, "Doan Thi Vanh Khuyen" },
                    { 3, false, "Bui Thi Loan" },
                    { 4, true, "Vu Hong Thai" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Code",
                keyValue: "EXE201");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Code",
                keyValue: "MLN111");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Code",
                keyValue: "PRM392");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Code",
                keyValue: "PRN231");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentSchedules");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TimeSlot",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

﻿// <auto-generated />
using System;
using Lab_PRN231.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab_PRN231.Migrations
{
    [DbContext(typeof(LabDBContext))]
    [Migration("20240605181701_u10")]
    partial class u10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lab_PRN231.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeSlot")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectCode");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseName = "SE1705-NET",
                            EndDate = new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectCode = "EXE201",
                            TimeSlot = "P20"
                        },
                        new
                        {
                            Id = 2,
                            CourseName = "SE1705-NET",
                            EndDate = new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectCode = "PRN231",
                            TimeSlot = "P63"
                        },
                        new
                        {
                            Id = 3,
                            CourseName = "SE1705-NET",
                            EndDate = new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectCode = "PRM392",
                            TimeSlot = "P42"
                        },
                        new
                        {
                            Id = 4,
                            CourseName = "EL1701",
                            EndDate = new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectCode = "MLN111",
                            TimeSlot = "P36"
                        });
                });

            modelBuilder.Entity("Lab_PRN231.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Slot")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TeacherId1");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Date = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slot = 1,
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            Date = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slot = 1,
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 3,
                            Date = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slot = 1,
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 4,
                            Date = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slot = 1,
                            TeacherId = 4
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 1,
                            Date = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slot = 2,
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 2,
                            Date = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slot = 2,
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 3,
                            Date = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slot = 2,
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 8,
                            CourseId = 4,
                            Date = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slot = 2,
                            TeacherId = 4
                        });
                });

            modelBuilder.Entity("Lab_PRN231.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gender = true,
                            Name = "Nguyen Minh Hieu",
                            StudentCode = "HE171547"
                        },
                        new
                        {
                            Id = 2,
                            Gender = true,
                            Name = "Vu Minh Hieu",
                            StudentCode = "HE172039"
                        },
                        new
                        {
                            Id = 3,
                            Gender = false,
                            Name = "Nguyen Minh Duy",
                            StudentCode = "HE172040"
                        });
                });

            modelBuilder.Entity("Lab_PRN231.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            CourseId = 1
                        },
                        new
                        {
                            StudentId = 1,
                            CourseId = 2
                        },
                        new
                        {
                            StudentId = 1,
                            CourseId = 3
                        },
                        new
                        {
                            StudentId = 1,
                            CourseId = 4
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 1
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 2
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 3
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 4
                        },
                        new
                        {
                            StudentId = 3,
                            CourseId = 1
                        },
                        new
                        {
                            StudentId = 3,
                            CourseId = 2
                        },
                        new
                        {
                            StudentId = 3,
                            CourseId = 3
                        },
                        new
                        {
                            StudentId = 3,
                            CourseId = 4
                        });
                });

            modelBuilder.Entity("Lab_PRN231.Models.StudentSchedule", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "ScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("StudentSchedules");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            ScheduleId = 1,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 1,
                            ScheduleId = 2,
                            Status = 1
                        },
                        new
                        {
                            StudentId = 1,
                            ScheduleId = 3,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 1,
                            ScheduleId = 4,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 2,
                            ScheduleId = 1,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 2,
                            ScheduleId = 2,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 2,
                            ScheduleId = 3,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 2,
                            ScheduleId = 4,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 3,
                            ScheduleId = 1,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 3,
                            ScheduleId = 2,
                            Status = 2
                        },
                        new
                        {
                            StudentId = 3,
                            ScheduleId = 3,
                            Status = 1
                        },
                        new
                        {
                            StudentId = 3,
                            ScheduleId = 4,
                            Status = 2
                        });
                });

            modelBuilder.Entity("Lab_PRN231.Models.Subject", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfSlot")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Code = "PRN231",
                            Name = "Building Cross-Platform Back-End Application With .NET",
                            NumberOfSlot = 22
                        },
                        new
                        {
                            Code = "PRM392",
                            Name = "Mobile Programming",
                            NumberOfSlot = 20
                        },
                        new
                        {
                            Code = "EXE201",
                            Name = "Experiential Entrepreneurship",
                            NumberOfSlot = 16
                        },
                        new
                        {
                            Code = "MLN111",
                            Name = "Philosophy of Marxism – Leninism",
                            NumberOfSlot = 12
                        });
                });

            modelBuilder.Entity("Lab_PRN231.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gender = false,
                            Name = "Le Phuong Chi"
                        },
                        new
                        {
                            Id = 2,
                            Gender = false,
                            Name = "Doan Thi Vanh Khuyen"
                        },
                        new
                        {
                            Id = 3,
                            Gender = false,
                            Name = "Bui Thi Loan"
                        },
                        new
                        {
                            Id = 4,
                            Gender = true,
                            Name = "Vu Hong Thai"
                        });
                });

            modelBuilder.Entity("Lab_PRN231.Models.Course", b =>
                {
                    b.HasOne("Lab_PRN231.Models.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Lab_PRN231.Models.Schedule", b =>
                {
                    b.HasOne("Lab_PRN231.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Lab_PRN231.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.HasOne("Lab_PRN231.Models.Teacher", null)
                        .WithMany("Schedules")
                        .HasForeignKey("TeacherId1");

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Lab_PRN231.Models.StudentCourse", b =>
                {
                    b.HasOne("Lab_PRN231.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab_PRN231.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Lab_PRN231.Models.StudentSchedule", b =>
                {
                    b.HasOne("Lab_PRN231.Models.Schedule", "Schedule")
                        .WithMany("StudentSchedules")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab_PRN231.Models.Student", "Student")
                        .WithMany("StudentSchedules")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Lab_PRN231.Models.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Lab_PRN231.Models.Schedule", b =>
                {
                    b.Navigation("StudentSchedules");
                });

            modelBuilder.Entity("Lab_PRN231.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("StudentSchedules");
                });

            modelBuilder.Entity("Lab_PRN231.Models.Subject", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Lab_PRN231.Models.Teacher", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}

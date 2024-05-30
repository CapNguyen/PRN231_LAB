using Lab_AttendanceManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Models
{
    public class LabDBContext : DbContext
    {
        public LabDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentSchedule> StudentSchedules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId })
            );
            modelBuilder.Entity<StudentSchedule>(entity =>
                entity.HasKey(sc => new { sc.StudentId, sc.ScheduleId })
            );
            Seeding(modelBuilder);
        }
        private void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().
            HasData(
            new Student() { Id = 1, Name = "Nguyen Minh Hieu", StudentCode = "HE171547", Gender = true },
            new Student() { Id = 2, Name = "Vu Minh Hieu", StudentCode = "HE172039", Gender = true },
            new Student() { Id = 3, Name = "Nguyen Minh Duy", StudentCode = "HE172040", Gender = false }
            );

            modelBuilder.Entity<Teacher>().
            HasData(
                new Teacher() { Id = 1, Name = "Le Phuong Chi", Gender = false },
                new Teacher() { Id = 2, Name = "Doan Thi Vanh Khuyen", Gender = false },
                new Teacher() { Id = 3, Name = "Bui Thi Loan", Gender = false },
                new Teacher() { Id = 4, Name = "Vu Hong Thai", Gender = true }
                );

            modelBuilder.Entity<Subject>().
            HasData(
                new Subject() { Code = "PRN231", Name = "Building Cross-Platform Back-End Application With .NET", NumberOfSlot = 22 },
                new Subject() { Code = "PRM392", Name = "Mobile Programming", NumberOfSlot = 20 },
                new Subject() { Code = "EXE201", Name = "Experiential Entrepreneurship", NumberOfSlot = 16 },
                new Subject() { Code = "MLN111", Name = "Philosophy of Marxism – Leninism", NumberOfSlot = 12 }
                );

            modelBuilder.Entity<Course>().
                HasData(
                new Course() { Id = 1, CourseName = "SE1705-NET", StartDate = DateTime.Parse("2024-05-06"), TimeSlot = "P20" },
                new Course() { Id = 2, CourseName = "SE1705-NET", StartDate = DateTime.Parse("2024-05-07"), TimeSlot = "P63" },
                new Course() { Id = 3, CourseName = "SE1705-NET", StartDate = DateTime.Parse("2024-05-06"), TimeSlot = "P42" },
                new Course() { Id = 4, CourseName = "EL1701", StartDate = DateTime.Parse("2024-05-07"), TimeSlot = "P36" }
                );

            modelBuilder.Entity<Schedule>().
                HasData(
                new Schedule() { Id = 1, Slot = 1, Date = DateTime.Parse("2024-05-06") },
                new Schedule() { Id = 2, Slot = 1, Date = DateTime.Parse("2024-05-07") },
                new Schedule() { Id = 3, Slot = 1, Date = DateTime.Parse("2024-05-06") },
                new Schedule() { Id = 4, Slot = 1, Date = DateTime.Parse("2024-05-07") }
                );

            modelBuilder.Entity<StudentCourse>().
                HasData(
                new StudentCourse() { CourseId = 1, StudentId = 1 },
                new StudentCourse() { CourseId = 2, StudentId = 1 },
                new StudentCourse() { CourseId = 3, StudentId = 1 },
                new StudentCourse() { CourseId = 4, StudentId = 1 },
                new StudentCourse() { CourseId = 1, StudentId = 2 },
                new StudentCourse() { CourseId = 2, StudentId = 2 },
                new StudentCourse() { CourseId = 3, StudentId = 2 },
                new StudentCourse() { CourseId = 4, StudentId = 2 },
                new StudentCourse() { CourseId = 1, StudentId = 3 },
                new StudentCourse() { CourseId = 2, StudentId = 3 },
                new StudentCourse() { CourseId = 3, StudentId = 3 },
                new StudentCourse() { CourseId = 4, StudentId = 3 }
                );

            modelBuilder.Entity<StudentSchedule>().
                HasData(
                new StudentSchedule() { ScheduleId = 1, StudentId = 1, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 2, StudentId = 1, Status = Status.Absent },
                new StudentSchedule() { ScheduleId = 3, StudentId = 1, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 4, StudentId = 1, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 1, StudentId = 2, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 2, StudentId = 2, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 3, StudentId = 2, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 4, StudentId = 2, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 1, StudentId = 3, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 2, StudentId = 3, Status = Status.Attended },
                new StudentSchedule() { ScheduleId = 3, StudentId = 3, Status = Status.Absent },
                new StudentSchedule() { ScheduleId = 4, StudentId = 3, Status = Status.Attended }

                );

        }
    }
}

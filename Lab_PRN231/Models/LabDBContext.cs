using Lab_PRN231.Models;
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
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

            modelBuilder.Entity<Teacher>().HasKey(t => t.Id);

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(c => c.Subject)
                    .WithMany(s => s.Courses)
                    .HasForeignKey(c => c.SubjectCode);

                entity.HasMany(c => c.Schedules)
                    .WithOne(s => s.Course)
                    .HasForeignKey(s => s.CourseId)
                    ;

            });

            modelBuilder.Entity<Subject>().HasKey(s => s.Code);

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasOne(s => s.Course)
                    .WithMany(c => c.Schedules)
                    .HasForeignKey(s => s.CourseId);

                entity.HasOne(s => s.Teacher)
                    .WithMany(t => t.Schedules)
                    .HasForeignKey(s => s.TeacherId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentCourses)
                    .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentCourses)
                    .HasForeignKey(sc => sc.CourseId);
            });

            modelBuilder.Entity<StudentSchedule>(entity =>
            {
                entity.HasKey(ss => new { ss.StudentId, ss.ScheduleId });

                entity.HasOne(ss => ss.Student)
                    .WithMany(s => s.StudentSchedules)
                    .HasForeignKey(ss => ss.StudentId);

                entity.HasOne(ss => ss.Schedule)
                    .WithMany(s => s.StudentSchedules)
                    .HasForeignKey(ss => ss.ScheduleId);
            });
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
            modelBuilder.Entity<Course>().
                HasData(
                new Course() { Id = 1, CourseName = "SE1705-NET", StartDate = DateTime.Parse("2024-05-06"), EndDate = DateTime.Parse("2024-07-15"), TimeSlot = "P24", SubjectCode = "EXE201" },
                new Course() { Id = 2, CourseName = "SE1705-NET", StartDate = DateTime.Parse("2024-05-07"), EndDate = DateTime.Parse("2024-07-20"), TimeSlot = "P63", SubjectCode = "PRN231" },
                new Course() { Id = 3, CourseName = "SE1705-NET", StartDate = DateTime.Parse("2024-05-06"), EndDate = DateTime.Parse("2024-07-17"), TimeSlot = "P42", SubjectCode = "PRM392" },
                new Course() { Id = 4, CourseName = "EL1701", StartDate = DateTime.Parse("2024-05-07"), EndDate = DateTime.Parse("2024-06-14"), TimeSlot = "P36", SubjectCode = "MLN111" }
                );
            modelBuilder.Entity<Subject>().
            HasData(
                new Subject() { Code = "PRN231", Name = "Building Cross-Platform Back-End Application With .NET", NumberOfSlot = 22 },
                new Subject() { Code = "PRM392", Name = "Mobile Programming", NumberOfSlot = 20 },
                new Subject() { Code = "EXE201", Name = "Experiential Entrepreneurship", NumberOfSlot = 16 },
                new Subject() { Code = "MLN111", Name = "Philosophy of Marxism – Leninism", NumberOfSlot = 12 }
                );
            modelBuilder.Entity<Schedule>().
               HasData(
               new Schedule() { Id = 1, Slot = 1, Date = DateTime.Parse("2024-05-06"), CourseId = 1, TeacherId = 2 },
               new Schedule() { Id = 2, Slot = 1, Date = DateTime.Parse("2024-05-07"), CourseId = 2, TeacherId = 1 },
               new Schedule() { Id = 3, Slot = 1, Date = DateTime.Parse("2024-05-06"), CourseId = 3, TeacherId = 3 },
               new Schedule() { Id = 4, Slot = 1, Date = DateTime.Parse("2024-05-07"), CourseId = 4, TeacherId = 4 }
               );
            //modelBuilder.Entity<StudentCourse>().
            //   HasData(
            //   new StudentCourse() { CourseId = 1, StudentId = 1 },
            //   new StudentCourse() { CourseId = 2, StudentId = 1 },
            //   new StudentCourse() { CourseId = 3, StudentId = 1 },
            //   new StudentCourse() { CourseId = 4, StudentId = 1 },
            //   new StudentCourse() { CourseId = 1, StudentId = 2 },
            //   new StudentCourse() { CourseId = 2, StudentId = 2 },
            //   new StudentCourse() { CourseId = 3, StudentId = 2 },
            //   new StudentCourse() { CourseId = 4, StudentId = 2 },
            //   new StudentCourse() { CourseId = 1, StudentId = 3 },
            //   new StudentCourse() { CourseId = 2, StudentId = 3 },
            //   new StudentCourse() { CourseId = 3, StudentId = 3 },
            //   new StudentCourse() { CourseId = 4, StudentId = 3 }
            //   );
            //modelBuilder.Entity<StudentSchedule>().
            //   HasData(
            //   new StudentSchedule() { ScheduleId = 1, StudentId = 1, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 2, StudentId = 1, Status = Status.Absent },
            //   new StudentSchedule() { ScheduleId = 3, StudentId = 1, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 4, StudentId = 1, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 1, StudentId = 2, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 2, StudentId = 2, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 3, StudentId = 2, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 4, StudentId = 2, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 1, StudentId = 3, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 2, StudentId = 3, Status = Status.Attended },
            //   new StudentSchedule() { ScheduleId = 3, StudentId = 3, Status = Status.Absent },
            //   new StudentSchedule() { ScheduleId = 4, StudentId = 3, Status = Status.Attended }
            //   );

        }
    }
}

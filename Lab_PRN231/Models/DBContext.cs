using Lab_AttendanceManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Xml.Linq;

namespace Lab_PRN231.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCourse> StudentsCourse { get; set; }
        public DbSet<StudentSchedule> StudentsSchedule { get; set; }
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
            //modelBuilder.Entity<Student>().
            //HasData(
            //new Student() { Id = 1, Name = "Vu Minh Hieu", StudentCode = "HE172039", Gender = true, email = "hieuvmhe172039@fpt.edu.vn" },
            //new Student() { Id = 2, Name = "Nguyen Minh Hieu", StudentCode = "HE172040", Gender = true, email = "hieunmhe172040@fpt.edu.vn" },
            //new Student() { Id = 3, Name = "Nguyen Minh Duy", StudentCode = "HE172041", Gender = true, email = "duynmhe172041@fpt.edu.vn" }
            //);
            //modelBuilder.Entity<Teacher>().
            //HasData(
            //    new Teacher() { Id = 1, Name = "Le Phuong Chi", TeacherCode = "ChiLP", gender = false }
            //    );
            //modelBuilder.Entity<Subject>().
            //HasData(
            //    new Subject() { Code = "PRM231", Name = "Building Cross-Platform Back-End Application With .NET", NumberOfSlot = 20 }
            //    );
        }
    }
}

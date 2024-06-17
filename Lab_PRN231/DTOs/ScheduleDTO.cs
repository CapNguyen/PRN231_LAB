using Lab_PRN231.Models;

namespace Lab_PRN231.DTOs
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public int? CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public Status Status { get; set; }

    }
}

using Lab_AttendanceManagement.Models;

namespace Lab_PRN231.DTOs
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public string? CourseName { get; set; }
        public string? TeacherName { get; set; }
    }
}

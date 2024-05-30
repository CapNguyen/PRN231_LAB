namespace Lab_AttendanceManagement.Models
{
    public class StudentSchedule
    {
        public int StudentId { get; set; }
        public int ScheduleId { get; set; }
        public Student? Student { get; set; }
        public Schedule? Schedule { get; set; }
    }
}
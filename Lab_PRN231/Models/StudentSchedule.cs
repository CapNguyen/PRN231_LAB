using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab_PRN231.Models
{
    public class StudentSchedule
    {
        public StudentSchedule()
        {
        }

        public StudentSchedule(int studentId, Student? student, int scheduleId, Schedule? schedule, Status status)
        {
            StudentId = studentId;
            Student = student;
            ScheduleId = scheduleId;
            Schedule = schedule;
            Status = status;
        }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }
        [DefaultValue(Status.NotYet)]
        public Status Status { get; set; }
    }
    public enum Status
    {
        NotYet,
        Absent,
        Attended 
    }
}
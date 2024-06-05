using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab_PRN231.Models
{
    public class StudentSchedule
    {
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
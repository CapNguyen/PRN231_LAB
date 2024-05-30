using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab_AttendanceManagement.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public string CourseId { get; set; }
        [DefaultValue(Status.NotYet)]
        public Status Status { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
    public enum Status
    {
        NotYet,
        Absent,
        Present
    }
}

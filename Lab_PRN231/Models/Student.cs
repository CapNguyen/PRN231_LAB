using System.ComponentModel.DataAnnotations;

namespace Lab_PRN231.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string StudentCode { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Gender { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<StudentSchedule>? StudentSchedules { get; set; } = new List<StudentSchedule>();
    }
}

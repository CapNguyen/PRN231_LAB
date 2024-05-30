using System.ComponentModel.DataAnnotations;

namespace Lab_PRN231.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string CourseName {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? TimeSlot { get; set; }

        public Subject? Subject { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
 
using System.ComponentModel.DataAnnotations;

namespace Lab_AttendanceManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string CourseName {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [RegularExpression(@"^[AP]\d{2}$", ErrorMessage = "Wrong Format!")]
        public string? TimeSlot { get; set; }

        public Subject? Subject { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }

    }
}

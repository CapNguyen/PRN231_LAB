
namespace Lab_PRN231.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public StudentCourse()
        {
        }

        public StudentCourse(int studentId, Student? student, int courseId, Course? course)
        {
            StudentId = studentId;
            Student = student;
            CourseId = courseId;
            Course = course;
        }
    }
       
}

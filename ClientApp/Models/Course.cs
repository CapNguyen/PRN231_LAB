

namespace ClientApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public string? TimeSlot { get; set; }
        public string? SubjectCode { get; set; }

        public int? TeacherId {  get; set; }

    }
}

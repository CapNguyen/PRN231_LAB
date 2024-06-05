using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_PRN231.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId {  get; set; } 
        public Teacher Teacher {  get; set; }
        public ICollection<StudentSchedule>? StudentSchedules { get; set; } = new List<StudentSchedule>();

    }
}

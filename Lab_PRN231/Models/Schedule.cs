namespace Lab_PRN231.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public Course? Course { get; set; }
        public Teacher? Teacher {  get; set; }
        public ICollection<StudentSchedule>? StudentSchedules { get; set; } = new List<StudentSchedule>();

    }
}

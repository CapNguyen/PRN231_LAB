using System.ComponentModel.DataAnnotations;

namespace Lab_PRN231.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Gender { get; set; }
        public ICollection<Schedule>? Schedules { get; set; } = new List<Schedule>();   
    }
}

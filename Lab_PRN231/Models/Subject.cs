using System.ComponentModel.DataAnnotations;

namespace Lab_PRN231.Models
{
    public class Subject
    {
        [Key]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int? NumberOfSlot { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}

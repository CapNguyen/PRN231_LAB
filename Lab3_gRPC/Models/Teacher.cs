using System.ComponentModel.DataAnnotations;

namespace Lab3_gRPC.Models
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

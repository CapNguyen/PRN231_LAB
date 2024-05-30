using System.ComponentModel.DataAnnotations;

namespace Lab_AttendanceManagement.Models
{
    public class Subject
    {
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int? NumberOfSlot { get; set; }
    }
}

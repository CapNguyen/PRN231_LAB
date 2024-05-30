using System.ComponentModel.DataAnnotations;

namespace Lab_PRN231.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Lab_PRN231.DTOs
{
    public class SubjectDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? NumberOfSlot { get; set; }
    }
}

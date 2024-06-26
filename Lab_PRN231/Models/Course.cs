﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_PRN231.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [RegularExpression(@"^[AP](\d)(?!\1)\d$")]
        public string TimeSlot { get; set; }
        [ForeignKey("Subject")]
        public string SubjectCode { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Schedule>? Schedules { get; set; } = new List<Schedule>();
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();

    }
}

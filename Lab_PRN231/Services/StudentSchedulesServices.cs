using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Services
{
    public class StudentSchedulesServices : IStudentSchedules
    {
        private readonly LabDBContext db;

        public StudentSchedulesServices(LabDBContext db)
        {
            this.db = db;
        }

        public async Task<bool> GenerateScheduleForCourse(int courseId)
        {
            Course c = db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (c == null)
            {
                return false;
            }

            return true;

        }


    }
}

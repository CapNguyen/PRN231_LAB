using Lab_PRN231.DTOs;
using Lab_PRN231.Models;

namespace Lab_PRN231.Services.IRepository
{
    public interface IStudentSchedules
    {
        Task<bool> GenerateScheduleForCourse(int courseId);
    }
}

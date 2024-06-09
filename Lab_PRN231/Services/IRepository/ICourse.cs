using Lab_PRN231.DTOs;
using Lab_PRN231.Models;

namespace Lab_PRN231.Services.IRepository
{
    public interface ICourse
    {
        Task<List<CourseDTO>> All();
        Task<List<CourseDTO>> GetAll();
        Task<CourseDTO> GetCourse(int id);
        Task AddCourse(CourseDTO CourseDTO);
        Task DeleteCourse(int id);
        Task UpdateCourse(int id, CourseDTO CourseDTO);
    }
}

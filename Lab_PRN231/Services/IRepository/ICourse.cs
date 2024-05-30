using Lab_PRN231.DTOs;

namespace Lab_PRN231.Services.IRepository
{
    public interface ICourse
    {
        Task<List<CourseDTO>> All();
        Task<CourseDTO> GetCourse(int id);
        Task AddCourse(CourseDTO CourseDTO);
        Task DeleteCourse(int id);
        Task UpdateCourse(int id, CourseDTO CourseDTO);
    }
}

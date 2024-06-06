using Lab_PRN231.DTOs;
using Lab_PRN231.Models;

namespace Lab_PRN231.Services.IRepository
{
    public interface IStudentCourses
    {
        Task<List<StudentDTO>> StudentInCourse(int courseId);
        Task AddStudentsToCourse(int courseId, List<int> studentId);
        Task DeletetStudentFromCourse(int courseId,List<int> studentId);
    }
}

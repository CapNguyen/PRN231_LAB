using Lab_PRN231.DTOs;

namespace Lab_PRN231.Services.IRepository
{
    public interface IStudent
    {
        Task<List<StudentDTO>> All();
        Task<StudentDTO> GetStudent(int id);
        Task AddStudent(StudentDTO studentDTO);
        Task DeleteStudent(int id);
        Task UpdateStudent(int id, StudentDTO studentDTO);
    }
}

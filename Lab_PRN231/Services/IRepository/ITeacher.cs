using Lab_PRN231.DTOs;

namespace Lab_PRN231.Services.IRepository
{
    public interface ITeacher
    {
        Task<List<TeacherDTO>> All();
        Task<TeacherDTO> GetTeacher(int id);
        Task AddTeacher(TeacherDTO teacherDTO);
        Task DeleteTeacher(int id);
        Task UpdateTeacher(int id, TeacherDTO teacherDTO);
    }
}

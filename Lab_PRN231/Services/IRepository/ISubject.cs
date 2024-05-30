using Lab_PRN231.DTOs;

namespace Lab_PRN231.Services.IRepository
{
    public interface ISubject
    {
        Task<List<SubjectDTO>> All();
        Task<SubjectDTO> GetSubject(string id);
        Task AddSubject(SubjectDTO SubjectDTO);
        Task DeleteSubject(string id);
        Task UpdateSubject(string id, SubjectDTO SubjectDTO);
    }
}

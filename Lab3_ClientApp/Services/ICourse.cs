using Lab3_ClientApp.Protos;

namespace Lab3_ClientApp.Services
{
    public interface ICourse
    {
        Task<AllCourse> GetAll();
        Task<CourseObject> GetById(int courseId);
        Task<StudentsInCourse> GetStudentsInCourse(int courseId);
    }
}

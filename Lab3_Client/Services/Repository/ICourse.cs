using Lab3_Client.Protos;

namespace Lab3_Client.Services.Repository
{
    public interface ICourse
    {
        Task<AllCourse> GetAll();
        Task<CourseObject> GetById(int courseId);
        Task<StudentsInCourse> GetStudentsInCourse(int courseId);
    }
}

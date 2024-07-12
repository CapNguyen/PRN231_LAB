using Grpc.Core;
using Lab3_gRPC.Models;
using Lab3_gRPC.Protos;
using Lab3_gRPC.Utils;

namespace Lab3_gPRC.Services
{
    public class CourseService : CourseServices.CourseServicesBase
    {
        private LabDBContext db;
        public CourseService(LabDBContext db)
        {
            this.db = db;
        }

        public override Task<AllCourse> GetAll(GetAllReq request, ServerCallContext context)
        {
            var resp = new AllCourse();
            var result = db.Courses.Select(c => new CourseObject
            {
                Id = c.Id,
                CourseName = c.CourseName,
                StartDate = gRPCConverter.toTimestamp(c.StartDate),
                TimeSlot = c.TimeSlot,
                SubjectCode = c.SubjectCode
            });
            resp.Course.AddRange(result);
            return Task.FromResult(resp);
        }

        public override Task<CourseObject> GetById(GetByIdRequest request, ServerCallContext context)
        {
            var result = db.Courses.Select(c => new CourseObject
            {
                Id = c.Id,
                CourseName = c.CourseName,
                StartDate = gRPCConverter.toTimestamp(c.StartDate),
                TimeSlot = c.TimeSlot,
                SubjectCode = c.SubjectCode
            }).FirstOrDefault(c => c.Id == request.CourseId);
            return Task.FromResult(result);

        }

        public override Task<StudentsInCourse> GetStudentsInCourse(GetByIdRequest request, ServerCallContext context)
        {
            var resp = new StudentsInCourse();
            var students = db.StudentCourses
                                    .Where(sc => sc.CourseId == request.CourseId)
                                    .Select(sc => new StudentObject
                                    {
                                        Id = sc.StudentId,
                                        StudentCode = sc.Student!.StudentCode,
                                        Name = sc.Student.Name,
                                        Gender = sc.Student.Gender,
                                    })
                                    .ToList();
            resp.Students.AddRange(students);
            return Task.FromResult(resp);
        }
    }
}

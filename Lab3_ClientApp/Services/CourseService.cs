using Grpc.Net.Client;
using Lab3_ClientApp.Protos;
using static Lab3_ClientApp.Protos.CourseServices;

namespace Lab3_ClientApp.Services
{
    public class CourseService : ICourse
    {
        private readonly GrpcChannel channel;
        private readonly CourseServicesClient client;
        public CourseService()
        {
           
            this.channel = GrpcChannel.ForAddress("https://localhost:5294");

            //this.channel = channel;
            this.client = new CourseServicesClient(this.channel);
        }

        public async Task<AllCourse> GetAll()
        {
            var request = new GetAllReq();
            var resp = await client.GetAllAsync(request);
            return resp;
        }

        public async Task<CourseObject> GetById(int courseId)
        {
            var request = new GetByIdRequest { CourseId=courseId};
            var resp = await client.GetByIdAsync(request);
            return resp;
        }

        public async Task<StudentsInCourse> GetStudentsInCourse(int courseId)
        {
            var request = new GetByIdRequest { CourseId = courseId };
            var resp = await client.GetStudentsInCourseAsync(request);
            return resp;
        }
    }
}

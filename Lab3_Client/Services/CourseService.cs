using Grpc.Net.Client;
using Lab3_Client.Protos;
using Lab3_Client.Services.Repository;
using static Lab3_Client.Protos.CourseServices;

namespace Lab3_Client.Services
{
    public class CourseService : ICourse
    {
        private readonly GrpcChannel channel;
        private readonly CourseServicesClient client;
        public CourseService(GrpcChannel channel)
        {
           
            //this.channel = GrpcChannel.ForAddress("https://localhost:5294");

            this.channel = channel;
            client = new CourseServicesClient(this.channel);
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

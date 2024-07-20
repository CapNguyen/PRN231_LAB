using Grpc.Net.Client;
using Lab3_Client.Protos;
using Lab3_Client.Services.Repository;
using static Lab3_Client.Protos.ScheduleServices;

namespace Lab3_Client.Services
{
    public class ScheduleService : ISchedule
    {
        private readonly GrpcChannel channel;
        private readonly ScheduleServicesClient client;
        public ScheduleService(GrpcChannel channel)
        {

            //this.channel = GrpcChannel.ForAddress("https://localhost:5294");

            this.channel = channel;
            client = new ScheduleServicesClient(this.channel);
        }

        public async Task<Attendances> AttendanceOfStudentInCourse(int studentId, int courseId)
        {
            var request = new AttendanceOfStudentInCourseReq { StudentId = studentId, CourseId = courseId };
            var resp = await client.AttendanceOfStudentInCourseAsync(request);
            return resp;
        }

        public async Task<Attendances> AttendancesInCourseBySlot(int courseId, int slot)
        {
            var request = new AttendancesInCourseBySlotReq { CourseId = courseId, SlotId = slot };
            var resp = await client.AttendancesInCourseBySlotAsync(request);
            return resp;
        }

        public async Task<TakeAttendanceResp> TakeAttendance(List<TakeAttendanceRequest> req)
        {
            var request = new TakeAttendanceReqs();
            foreach (var r in req)
            {
                var temp = new TakeAttendanceReq { ScheduleId = r.ScheduleId, StudentId = r.StudentId, Status = r.Status };
                request.Request.Add(temp);
            }
            var resp = await client.TakeAttendanceAsync(request);
            return resp;

        }

        public async Task<Attendances> SchedulesByCourse(int courseId)
        {
            var request = new SchedulesByCourseReq{ CourseId = courseId };
            var resp = await client.SchedulesByCourseAsync(request);
            return resp;
        }

    }
}

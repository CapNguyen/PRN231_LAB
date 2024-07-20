using Lab3_Client.Protos;

namespace Lab3_Client.Services.Repository
{
    public interface ISchedule
    {
        Task<Attendances> AttendanceOfStudentInCourse(int studentId, int courseId);
        Task<Attendances> AttendancesInCourseBySlot(int courseId, int slot);
        Task<TakeAttendanceResp> TakeAttendance(List<TakeAttendanceRequest> req);

        Task<Attendances> SchedulesByCourse(int courseId);
    }

    public class TakeAttendanceRequest
    {
        public int StudentId { get; set; }
        public int ScheduleId { get; set; }
        public Status Status { get; set; }
    }
}

using Lab_PRN231.Controllers;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;

namespace Lab_PRN231.Services.IRepository
{
    public interface ISchedule
    {
        Task<List<ScheduleDTO>> All();
        Task<List<ScheduleDTO>> AttendancesInCourse(int courseId);
        Task<List<ScheduleDTO>> AttendancesInCourseBySlot(int courseId, int slot);
        Task<List<ScheduleDTO>> AttendanceOfStudent(int studentId);
        Task<ScheduleDTO> TakeAttendance(int studentId, int scheduleId, Status status);
        Task<List<ScheduleDTO>> TakeAttendances(List<TakeAttendanceRequest> requests);

    }
}

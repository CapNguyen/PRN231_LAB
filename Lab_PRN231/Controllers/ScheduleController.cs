using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Lab_PRN231.Controllers
{
    [ApiController]
    [Route("lab/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly ISchedule s_services;
        private readonly IStudentSchedules ss_services;

        public ScheduleController(ISchedule services, IStudentSchedules ss_services)
        {
            this.s_services = services;
            this.ss_services = ss_services;
        }

        [HttpGet]
        [EnableQuery]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            var schedules = await s_services.All();
            return Ok(schedules);
        }
        [HttpGet]
        [EnableQuery]
        [Route("All/Course/{courseId}")]
        public async Task<IActionResult> AttendancesInCourse([FromRoute] int courseId)
        {
            var schedules = await s_services.AttendancesInCourse(courseId);
            return Ok(schedules);
        }
        [HttpGet]
        [EnableQuery]
        [Route("All/Student/{studentId}")]
        public async Task<IActionResult> AttendanceOfStudent([FromRoute] int studentId)
        {
            var schedules = await s_services.AttendanceOfStudent(studentId);
            return Ok(schedules);
        }

        [HttpPost]
        [EnableQuery]
        [Route("TakeAttendance")]
        public async Task<IActionResult> TakeAttendance([FromBody] TakeAttendanceRequest req)
        {
            var schedule = await s_services.TakeAttendance(req.StudentId, req.ScheduleId, req.Status);
            return Ok(schedule);
        }

        [HttpGet]
        [Route("GenerateSchedules/{courseId}")]
        public async Task<IActionResult> GenerateScheduleForCourse([FromRoute] int courseId)
        {
            var check = await ss_services.GenerateScheduleForCourse(courseId);
            return Ok(check);
        }
    }
    public class TakeAttendanceRequest
    {
        public int StudentId { get; set; }
        public int ScheduleId { get; set; }
        public Status Status { get; set; }
    }
}

using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Collections.Generic;

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
        [Route("Course/{courseId}")]
        public async Task<IActionResult> AttendancesInCourse([FromRoute] int courseId)
        {
            var schedules = await s_services.AttendancesInCourse(courseId);
            return Ok(schedules);
        }

        [HttpGet]
        [EnableQuery]
        [Route("Course/{courseId}/{slot}")]
        public async Task<IActionResult> AttendancesInCourseBySlot([FromRoute] int courseId, [FromRoute] int slot)
        {
            var schedules = await s_services.AttendancesInCourseBySlot(courseId, slot);
            return Ok(schedules);
        }

        [HttpGet]
        [EnableQuery]
        [Route("Student/{studentId}")]
        public async Task<IActionResult> AttendanceOfStudent([FromRoute] int studentId)
        {
            var schedules = await s_services.AttendanceOfStudent(studentId);
            return Ok(schedules);
        }

        [HttpPost]
        [EnableQuery]
        [Route("TakeAttendances")]
        public async Task<IActionResult> TakeAttendance([FromBody] List<TakeAttendanceRequest> req)
        {
            var schedule = await s_services.TakeAttendances(req);
            return Ok(schedule);
        }

        [HttpPost]
        [Route("GenerateSchedules")]
        public async Task<IActionResult> GenerateScheduleForCourse([FromBody] CourseDTO courseDTO)
        {
            await ss_services.GenerateScheduleForCourse(courseDTO);
            return Ok();
        }
    }

    public class TakeAttendanceRequest
    {
        public int StudentId { get; set; }
        public int ScheduleId { get; set; }
        public Status Status { get; set; }
    }

}

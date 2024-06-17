using ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ClientApp.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly HttpClient client = null;
        private string ScheduleApiUrl = "";

        public ScheduleController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ScheduleApiUrl = $"https://localhost:7195/lab/Schedule";
        }

        public async Task<IActionResult> Index()
        {
            var url = ScheduleApiUrl + "/All";
            HttpResponseMessage response = await client.GetAsync(url);
            var result = response.Content.ReadFromJsonAsync<List<Schedule>>().Result;
            return View(result);
        }

        [HttpGet("Schedule/TeacherTimeTable/{teacherId}/{from}/{to}")]
        public async Task<IActionResult> TeacherTimeTable(int teacherId, DateTime from, DateTime to)
        {
            var url = ScheduleApiUrl + $"/All?$filter=teacherId eq {teacherId} and date ge {from:yyyy-MM-dd} and date lt {to:yyyy-MM-dd}";
            HttpResponseMessage response = await client.GetAsync(url);
            var result = response.Content.ReadFromJsonAsync<List<Schedule>>().Result;
            return View(result);
        }

        [HttpGet("Schedule/Course/{courseId}/Slot/{slot}")]
        public async Task<IActionResult> AttendancesByCourseSlot(int courseId, int slot)
        {
            var url = ScheduleApiUrl + $"/Course/{courseId}/{slot}";
            HttpResponseMessage response = await client.GetAsync(url);
            var result = response.Content.ReadFromJsonAsync<List<Schedule>>().Result;
            return View(result);
        }

        [HttpGet("Schedule/TakeAttendance/{courseId}/{slot}")]
        public async Task<IActionResult> TakeAttendance(int courseId, int slot)
        {
            var url = ScheduleApiUrl + $"/Course/{courseId}/{slot}";
            HttpResponseMessage response = await client.GetAsync(url);
            var result = response.Content.ReadFromJsonAsync<List<Schedule>>().Result;
            return View(result);
        }

        [HttpPost("Schedule/TakeAttendance/{courseId}/{slot}")]
        public async Task<IActionResult> TakeAttendance(List<Attendance> attendances)
        {
            var url = ScheduleApiUrl + $"/TakeAttendances";
            HttpResponseMessage response = await client.PostAsJsonAsync(url, attendances);
            var result = response.Content.ReadFromJsonAsync<List<Schedule>>().Result;
            return View(result);
        }

        [HttpGet("Schedule/Student/{studentId}/Course/{courseId}")]
        public async Task<IActionResult> AttendancesInCourse(int studentId, int courseId)
        {
            var url = ScheduleApiUrl + $"/Student/{studentId}?$filter= courseId eq {courseId}";
            HttpResponseMessage response = await client.GetAsync(url);
            var result = response.Content.ReadFromJsonAsync<List<Schedule>>().Result;
            return View(result);
        }

        [HttpGet("Schedule/StudentTimetable/{studentId}/{from}/{to}")]
        public async Task<IActionResult> StudentTimetable(int studentId, DateTime from, DateTime to)
        {
            var url = ScheduleApiUrl + $"/Student/{studentId}?$filter=date ge {from:yyyy-MM-dd} and date lt {to:yyyy-MM-dd}";
            HttpResponseMessage response = await client.GetAsync(url);
            var result = response.Content.ReadFromJsonAsync<List<Schedule>>().Result;
            return View(result);
        }
    }
}

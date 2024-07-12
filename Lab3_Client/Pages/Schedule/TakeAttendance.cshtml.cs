using Lab3_Client.Protos;
using Lab3_Client.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_Client.Pages.Schedule
{
    public class TakeAttendanceModel : PageModel
    {
        private readonly ISchedule services;
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

        [BindProperty]
        public int CourseId { get; set; }
        [BindProperty]
        public int Slot { get; set; }
        [BindProperty]
        public string Status { get; set; }
        [BindProperty]
        public List<TakeAttendanceRequest> AttendanceRequests { get; set; } = new List<TakeAttendanceRequest>();
        public TakeAttendanceModel(ISchedule services)
        {
            this.services = services;
        }

        public async Task<IActionResult> OnGet(int courseId, int slot)
        {
            CourseId = courseId;
            Slot = slot;
            var updatedResp = await services.AttendancesInCourseBySlot(courseId, slot);
            Attendances.Clear();
            Attendances.AddRange(updatedResp.Attendances_);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var resp = await services.TakeAttendance(AttendanceRequests);
            Status = resp.Status;
            Console.WriteLine(resp.Message);
            var updatedResp = await services.AttendancesInCourseBySlot(CourseId, Slot);
            Attendances.Clear();
            Attendances.AddRange(updatedResp.Attendances_);
            return Page();
        }


    }
}

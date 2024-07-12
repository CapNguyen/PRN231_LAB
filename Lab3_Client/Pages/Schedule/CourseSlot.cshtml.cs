using Lab3_Client.Protos;
using Lab3_Client.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_Client.Pages.Schedule
{
    public class CourseSlotModel : PageModel
    {
        private readonly ISchedule services;
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

        public CourseSlotModel(ISchedule services)
        {
            this.services = services;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(int courseId, int slot)
        {
            if (courseId == 0 || slot == 0)
            {
                return RedirectToPage();
            }
            var resp = await services.AttendancesInCourseBySlot(courseId, slot);
            Attendances.AddRange(resp.Attendances_);
            return Page();
        }
    }
}

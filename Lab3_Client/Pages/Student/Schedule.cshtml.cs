using Lab3_Client.Protos;
using Lab3_Client.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_Client.Pages.Student
{
    public class ScheduleModel : PageModel
    {
        private readonly ISchedule services;
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

        public ScheduleModel(ISchedule services)
        {
            this.services = services;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(int courseId, int studentId)
        {
            if (courseId == 0|| studentId == 0)
            {
                return RedirectToPage();
            }
            var resp = await services.AttendanceOfStudentInCourse(courseId, studentId);
            Attendances.AddRange(resp.Attendances_);
            return Page();
        }
    }
}

using Lab3_Client.Protos;
using Lab3_Client.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_Client.Pages.Schedule
{
    public class CourseModel : PageModel
    {
        private readonly ISchedule services;
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

        public CourseModel(ISchedule services)
        {
            this.services = services;
        }

        //public async Task<IActionResult> OnGet()
        //{

        //}
    }
}

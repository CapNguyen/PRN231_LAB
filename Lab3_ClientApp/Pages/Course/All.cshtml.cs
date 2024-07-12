using Lab3_ClientApp.Protos;
using Lab3_ClientApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_ClientApp.Pages
{
    public class CourseModel : PageModel
    {
        private readonly ICourse services;
        public List<CourseObject> Courses { get; private set; } = new List<CourseObject>();

        public CourseModel(ICourse services)
        {
            this.services = services;
        }

        public async Task<IActionResult> OnGet()
        {
            var resp = await services.GetAll();

            Courses = resp.Course.ToList();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int studentId)
        {
            var resp = await services.GetById(studentId);
            Courses.Clear();
            Courses.Add(resp);

            return Page();
        }
    }
}

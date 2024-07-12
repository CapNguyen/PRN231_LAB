using Lab3_Client.Protos;
using Lab3_Client.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_Client.Pages
{
    public class CourseModel : PageModel
    {
        private readonly ICourse services;
        public List<CourseObject> Courses { get; set; } = new List<CourseObject>();

        public CourseModel(ICourse services)
        {
            this.services = services;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var resp = await services.GetAll();

            Courses = resp.Course.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int courseId)
        {
            if (courseId == 0)
            {
                return RedirectToPage();
            }

            var resp = await services.GetById(courseId);
            Courses.Clear();
            Courses.Add(resp);

            return Page();
        }

    }
}

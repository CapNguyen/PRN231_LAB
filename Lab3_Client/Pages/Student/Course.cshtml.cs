using Lab3_Client.Protos;
using Lab3_Client.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_ClientApp.Pages.Course
{
    public class StudentsInCourseModel : PageModel
    {
        private readonly ICourse services;
        public List<StudentObject> Students { get; set; } = new List<StudentObject>();

        public StudentsInCourseModel(ICourse services)
        {
            this.services = services;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(int courseId)
        {
            if (courseId == 0)
            {
                return RedirectToPage();
            }

            var resp = await services.GetStudentsInCourse(courseId);
            Students.AddRange(resp.Students);

            return Page();
        }
    }
}

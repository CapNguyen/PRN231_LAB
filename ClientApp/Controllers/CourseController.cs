using ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ClientApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient client = null;
        private string courseAPIUrl = "";

        public CourseController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            courseAPIUrl = $"https://localhost:7195/lab/Course/";
        }

        public async Task<IActionResult> Index()
        {
            var url = courseAPIUrl + "All";
            HttpResponseMessage response = await client.GetAsync(url);
            var result = response.Content.ReadFromJsonAsync<List<Course>>().Result;
            return View(result);
        }
    }
}

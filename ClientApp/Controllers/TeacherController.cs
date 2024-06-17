using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

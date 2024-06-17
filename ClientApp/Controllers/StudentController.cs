using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

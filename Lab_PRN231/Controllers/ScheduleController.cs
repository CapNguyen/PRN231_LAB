using Lab_PRN231.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Lab_PRN231.Controllers
{
    [ApiController]
    [Route("lab/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly ISchedule services;

        public ScheduleController(ISchedule services)
        {
            this.services = services;
        }

        [HttpGet]
        [EnableQuery]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok();
        }
    }
}

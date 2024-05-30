using Lab_PRN231.DTOs;
using Lab_PRN231.Services;
using Lab_PRN231.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Lab_PRN231.Controllers
{
    [ApiController]
    [Route("lab/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourse services;

        public CourseController(ICourse services)
        {
            this.services = services;
        }

        [HttpGet]
        [EnableQuery]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            var courses = await services.All();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> Get(int id)
        {
            CourseDTO course = await services.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CourseDTO courseDTO)
        {
                await services.AddCourse(courseDTO);
                return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseDTO courseDTO)
        {
            await services.UpdateCourse(id, courseDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await services.DeleteCourse(id);
            return Ok();
        }
    }
}

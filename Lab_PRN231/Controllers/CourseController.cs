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
        private readonly ICourse course_services;
        private readonly IStudentCourses studentCourses_services;

        public CourseController(ICourse services, IStudentCourses studentCourses_services)
        {
            this.course_services = services;
            this.studentCourses_services = studentCourses_services;
        }

        [HttpGet]
        [EnableQuery]
        [Route("All")]
        public async Task<IActionResult> Index()
        {
            var courses = await course_services.All();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> Get(int id)
        {
            CourseDTO course = await course_services.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseDTO courseDTO)
        {
            await course_services.AddCourse(courseDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseDTO courseDTO)
        {
            await course_services.UpdateCourse(id, courseDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await course_services.DeleteCourse(id);
            return Ok();
        }
        [HttpGet]
        [Route("Students/{courseId}")]
        public async Task<IActionResult> GetStudentsInCourse([FromRoute] int courseId)
        {
            var students = await studentCourses_services.StudentInCourse(courseId);
            return Ok(students);
        }
        [HttpPost]
        [Route("Students")]
        public async Task<IActionResult> AddStudentToCourse([FromBody] CourseRequest req)
        {
            await studentCourses_services.AddStudentsToCourse(req.CourseId, req.StudentIds);
            return Ok();
        }
        [HttpDelete]
        [Route("Students")]
        public async Task<IActionResult> DeletetStudentFromCourse([FromBody] CourseRequest req)
        {
            await studentCourses_services.DeletetStudentFromCourse(req.CourseId, req.StudentIds);
            return Ok();
        }
    }

    public class CourseRequest
    {
        public int CourseId { get; set; }
        public List<int> StudentIds { get; set; }
    }
}

using Lab_PRN231.DTOs;
using Lab_PRN231.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Lab_PRN231.Controllers
{
    [ApiController]
    [Route("lab/[controller]")]
    public class TeacherController : Controller
    {
        private readonly ITeacher services;

        public TeacherController(ITeacher services)
        {
            this.services = services;
        }

        [HttpGet]
        [EnableQuery]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            var teachers = await services.All();
            return Ok(teachers);
        }
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<TeacherDTO>> Get(int id)
        {
            TeacherDTO teacher = await services.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TeacherDTO teacherDTO)
        {
            await services.AddTeacher(teacherDTO);
            return Ok(teacherDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TeacherDTO teacherDTO)
        {
            await services.UpdateTeacher(id, teacherDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await services.DeleteTeacher(id);
            return Ok();
        }
    }
}

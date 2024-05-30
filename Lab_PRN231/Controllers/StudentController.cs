using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Lab_PRN231.Controllers
{
    [ApiController]
    [Route("lab/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudent services;

        public StudentController(IStudent services)
        {
            this.services = services;
        }

        [HttpGet]
        [EnableQuery]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            var students = await services.All();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> Get(int id)
        {
            StudentDTO student = await services.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentDTO studentDTO)
        {
            await services.AddStudent(studentDTO);
            return Ok(studentDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDTO studentDTO)
        {
            await services.UpdateStudent(id, studentDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await services.DeleteStudent(id);
            return Ok();
        }
    }
}

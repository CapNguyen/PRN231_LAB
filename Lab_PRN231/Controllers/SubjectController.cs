using Lab_PRN231.DTOs;
using Lab_PRN231.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Lab_PRN231.Controllers
{
    [ApiController]
    [Route("lab/[controller]")]
    public class SubjectController : Controller
    {
        private readonly ISubject services;

        public SubjectController(ISubject services)
        {
            this.services = services;
        }

        [HttpGet]
        [EnableQuery]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            var subjects = await services.All();
            return Ok(subjects); 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDTO>> Get(string id)
        {
            SubjectDTO subject = await services.GetSubject(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubjectDTO subjectDTO)
        {
            await services.AddSubject(subjectDTO);
            return Ok(subjectDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SubjectDTO subjectDTO)
        {
            await services.UpdateSubject(id, subjectDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services.DeleteSubject(id);
            return Ok();
        }
    }
}

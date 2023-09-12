using Microsoft.AspNetCore.Mvc;
using COREContacts.Data;
using COREContacts.Models;
using System.Collections.Generic;

namespace COREContacts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;

        public EducationsController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Education>> GetEducations()
        {
            return Ok(_educationRepository.GetEducations());
        }

        [HttpGet("{id}")]
        public ActionResult<Education> GetEducationById(int id) 
        {
            var education = _educationRepository.GetEducationById(id);
            if (education == null)
            {
                return NotFound();
            }
            return Ok(education);
        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            _educationRepository.AddEducation(education);
            return CreatedAtAction(nameof(GetEducations), new { id = education.ID }, education);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEducation(int id, Education education)
        {
            if (id != education.ID)
            {
                return BadRequest();
            }

            _educationRepository.UpdateEducation(education);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEducation(int id)
        {
            _educationRepository.DeleteEducation(id);
            return NoContent();
        }
    }
}

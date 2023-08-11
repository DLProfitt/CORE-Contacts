using Microsoft.AspNetCore.Mvc;
using RefactorResume.Data;
using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumesController : ControllerBase
    {
        private readonly IResumeRepository _resumeRepository;

        public ResumesController(IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Resume>> GetAllResumes()
        {
            return Ok(_resumeRepository.GetAllResumes());
        }

        [HttpGet("{id}")]
        public ActionResult<Resume> GetResume(int id)
        {
            var resume = _resumeRepository.GetResume(id);
            if (resume == null)
            {
                return NotFound();
            }
            return Ok(resume);
        }

        [HttpPost]
        public ActionResult<Resume> AddResume(Resume resume)
        {
            _resumeRepository.AddResume(resume);
            return CreatedAtAction(nameof(GetResume), new { id = resume.ID }, resume);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateResume(int id, Resume resume)
        {
            if (id != resume.ID)
            {
                return BadRequest();
            }

            var existingResume = _resumeRepository.GetResume(id);
            if (existingResume == null)
            {
                return NotFound();
            }

            _resumeRepository.UpdateResume(resume);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteResume(int id)
        {
            var existingResume = _resumeRepository.GetResume(id);
            if (existingResume == null)
            {
                return NotFound();
            }

            _resumeRepository.DeleteResume(id);
            return NoContent();
        }
    }
}

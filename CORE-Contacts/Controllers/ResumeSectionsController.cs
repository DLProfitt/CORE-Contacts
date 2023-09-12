using Microsoft.AspNetCore.Mvc;
using RefactorResume.Data;
using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeSectionsController : ControllerBase
    {
        private readonly IResumeSectionRepository _resumeSectionRepository;

        public ResumeSectionsController(IResumeSectionRepository resumeSectionRepository)
        {
            _resumeSectionRepository = resumeSectionRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResumeSection>> GetAllResumeSections()
        {
            var resumeSections = _resumeSectionRepository.GetAll();
            return Ok(resumeSections);
        }

        [HttpGet("{id}")]
        public ActionResult<ResumeSection> GetResumeSectionById(int id)
        {
            var resumeSection = _resumeSectionRepository.Get(id);
            if (resumeSection == null)
            {
                return NotFound();
            }
            return resumeSection;
        }

        [HttpPost]
        public ActionResult<ResumeSection> AddResumeSection(ResumeSection resumeSection)
        {
            _resumeSectionRepository.Add(resumeSection);
            return CreatedAtAction(nameof(GetResumeSectionById), new { id = resumeSection.ID }, resumeSection);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateResumeSection(int id, ResumeSection resumeSection)
        {
            if (id != resumeSection.ID)
            {
                return BadRequest();
            }

            var existingResumeSection = _resumeSectionRepository.Get(id);
            if (existingResumeSection == null)
            {
                return NotFound();
            }

            _resumeSectionRepository.Update(resumeSection);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteResumeSection(int id)
        {
            var existingResumeSection = _resumeSectionRepository.Get(id);
            if (existingResumeSection == null)
            {
                return NotFound();
            }

            _resumeSectionRepository.Delete(id);
            return NoContent();
        }
    }
}

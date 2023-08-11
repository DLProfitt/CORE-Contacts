using Microsoft.AspNetCore.Mvc;
using RefactorResume.Data;
using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationsController : ControllerBase
    {
        private readonly ICertificationRepository _certificationRepository;

        public CertificationsController(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }

        // GET: api/Certifications
        [HttpGet]
        public ActionResult<IEnumerable<Certification>> GetAllCertifications()
        {
            return Ok(_certificationRepository.GetAllCertifications());
        }

        // GET: api/Certifications/5
        [HttpGet("{id}")]
        public ActionResult<Certification> GetCertificationById(int id)
        {
            var certification = _certificationRepository.GetCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }
            return Ok(certification);
        }

        // POST: api/Certifications
        [HttpPost]
        public ActionResult<Certification> AddCertification(Certification certification)
        {
            _certificationRepository.AddCertification(certification);
            return CreatedAtAction(nameof(GetCertificationById), new { id = certification.ID }, certification);
        }

        // PUT: api/Certifications/5
        [HttpPut("{id}")]
        public IActionResult UpdateCertification(int id, Certification certification)
        {
            if (id != certification.ID)
            {
                return BadRequest();
            }

            _certificationRepository.UpdateCertification(certification);
            return NoContent();
        }

        // DELETE: api/Certifications/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCertification(int id)
        {
            var certification = _certificationRepository.GetCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }

            _certificationRepository.DeleteCertification(id);
            return NoContent();
        }
    }
}

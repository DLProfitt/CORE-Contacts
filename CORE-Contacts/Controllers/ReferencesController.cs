using Microsoft.AspNetCore.Mvc;
using COREContacts.Models;
using COREContacts.Repositories;
using System.Collections.Generic;

namespace COREContacts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferencesController : ControllerBase
    {
        private readonly IReferenceRepository _referenceRepository;

        public ReferencesController(IReferenceRepository referenceRepository)
        {
            _referenceRepository = referenceRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reference>> GetAllReferences()
        {
            var references = _referenceRepository.GetAllReferences();
            return Ok(references);
        }

        [HttpGet("{id}")]
        public ActionResult<Reference> GetReferenceById(int id)
        {
            var reference = _referenceRepository.GetReferenceById(id);
            if (reference == null)
            {
                return NotFound();
            }
            return Ok(reference);
        }

        [HttpPost]
        public ActionResult<Reference> AddReference([FromBody] Reference reference)
        {
            _referenceRepository.AddReference(reference);
            return CreatedAtAction(nameof(GetReferenceById), new { id = reference.ID }, reference);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateReference(int id, [FromBody] Reference reference)
        {
            if (id != reference.ID)
            {
                return BadRequest();
            }

            _referenceRepository.UpdateReference(reference);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReference(int id)
        {
            _referenceRepository.DeleteReference(id);
            return NoContent();
        }
    }
}

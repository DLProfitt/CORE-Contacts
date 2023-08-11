using Microsoft.AspNetCore.Mvc;
using RefactorResume.Data;
using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalInformationController : ControllerBase
    {
        private readonly IPersonalInformationRepository _personalInformationRepository;

        public PersonalInformationController(IPersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<PersonalInformation> Get(int id)
        {
            var personalInformation = _personalInformationRepository.Get(id);
            if (personalInformation == null)
            {
                return NotFound();
            }
            return personalInformation;
        }

        [HttpPost]
        public ActionResult Add(PersonalInformation personalInformation)
        {
            _personalInformationRepository.Add(personalInformation);
            return CreatedAtAction(nameof(Get), new { id = personalInformation.ID }, personalInformation);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, PersonalInformation personalInformation)
        {
            if (id != personalInformation.ID)
            {
                return BadRequest("ID mismatch");
            }

            var existingPersonalInformation = _personalInformationRepository.Get(id);
            if (existingPersonalInformation == null)
            {
                return NotFound();
            }

            _personalInformationRepository.Update(personalInformation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingPersonalInformation = _personalInformationRepository.Get(id);
            if (existingPersonalInformation == null)
            {
                return NotFound();
            }

            _personalInformationRepository.Delete(id);
            return NoContent();
        }
    }
}

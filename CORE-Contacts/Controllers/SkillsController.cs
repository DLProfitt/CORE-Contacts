using Microsoft.AspNetCore.Mvc;
using COREContacts.Models;
using COREContacts.Repositories;
using System.Collections.Generic;

namespace COREContacts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;

        public SkillsController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet]
        public ActionResult<List<Skill>> GetAllSkills()
        {
            return _skillRepository.GetAllSkills();
        }

        [HttpGet("{id}")]
        public ActionResult<Skill> GetSkillById(int id)
        {
            var skill = _skillRepository.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return skill;
        }

        [HttpPost]
        public ActionResult AddSkill([FromBody] Skill skill)
        {
            _skillRepository.AddSkill(skill);
            return CreatedAtAction(nameof(GetSkillById), new { id = skill.ID }, skill);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSkill(int id, [FromBody] Skill skill)
        {
            if (id != skill.ID)
            {
                return BadRequest("ID in URL must match ID in skill object");
            }

            var existingSkill = _skillRepository.GetSkillById(id);
            if (existingSkill == null)
            {
                return NotFound();
            }

            _skillRepository.UpdateSkill(skill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSkill(int id)
        {
            var existingSkill = _skillRepository.GetSkillById(id);
            if (existingSkill == null)
            {
                return NotFound();
            }

            _skillRepository.DeleteSkill(id);
            return NoContent();
        }
    }
}

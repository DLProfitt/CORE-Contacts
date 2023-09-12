using Microsoft.AspNetCore.Mvc;
using RefactorResume.Models;
using RefactorResume.Repositories;
using System.Collections.Generic;

namespace RefactorResume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjectivesController : ControllerBase
    {
        private readonly IObjectiveRepository _objectiveRepository;

        public ObjectivesController(IObjectiveRepository objectiveRepository)
        {
            _objectiveRepository = objectiveRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Objective> GetObjectiveById(int id)
        {
            var objective = _objectiveRepository.GetObjective(id);
            if (objective == null)
            {
                return NotFound();
            }
            return objective;
        }

        [HttpPost]
        public ActionResult<Objective> AddObjective(Objective objective)
        {
            _objectiveRepository.AddObjective(objective);
            return CreatedAtAction(nameof(GetObjectiveById), new { id = objective.ID }, objective);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateObjective(int id, Objective objective)
        {
            if (id != objective.ID)
            {
                return BadRequest();
            }

            _objectiveRepository.UpdateObjective(objective);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteObjective(int id)
        {
            _objectiveRepository.DeleteObjective(id);
            return NoContent();
        }
    }
}

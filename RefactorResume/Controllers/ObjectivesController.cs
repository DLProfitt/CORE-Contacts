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

        // GET: api/objectives/{id}
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

        // POST: api/objectives
        [HttpPost]
        public ActionResult<Objective> AddObjective(Objective objective)
        {
            _objectiveRepository.AddObjective(objective);
            return CreatedAtAction(nameof(GetObjectiveById), new { id = objective.ID }, objective);
        }

        // PUT: api/objectives/{id}
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

        // DELETE: api/objectives/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteObjective(int id)
        {
            _objectiveRepository.DeleteObjective(id);
            return NoContent();
        }
    }
}

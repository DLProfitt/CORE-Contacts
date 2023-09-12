using Microsoft.AspNetCore.Mvc;
using RefactorResume.Models;
using RefactorResume.Repositories;
using System.Collections.Generic;

namespace RefactorResume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetAllProjects()
        {
            return Ok(_projectRepository.GetAllProjects());
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectById(int id)
        {
            var project = _projectRepository.GetAllProjects();
            var selectedProject = new Project();

            foreach (var item in project)
            {
                if (item.ID == id)
                {
                    selectedProject = item;
                    break;
                }
            }

            if (selectedProject.ID == 0)
            {
                return NotFound();
            }

            return Ok(selectedProject);
        }

        [HttpPost]
        public ActionResult<Project> AddProject(Project project)
        {
            _projectRepository.AddProject(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = project.ID }, project);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, Project project)
        {
            if (id != project.ID)
            {
                return BadRequest();
            }

            _projectRepository.UpdateProject(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            _projectRepository.DeleteProject(id);
            return NoContent();
        }
    }
}

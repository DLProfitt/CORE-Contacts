﻿using Microsoft.AspNetCore.Mvc;
using RefactorResume.Data;
using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkExperiencesController : ControllerBase
    {
        private readonly IWorkExperienceRepository _workExperienceRepository;

        public WorkExperiencesController(IWorkExperienceRepository workExperienceRepository)
        {
            _workExperienceRepository = workExperienceRepository;
        }

        [HttpGet]
        public IEnumerable<WorkExperience> GetAllWorkExperiences()
        {
            return _workExperienceRepository.GetAllWorkExperiences();
        }

        [HttpGet("{id}")]
        public ActionResult<WorkExperience> GetWorkExperienceById(int id) // Updated action
        {
            var workExperience = _workExperienceRepository.GetWorkExperienceById(id);
            if (workExperience == null)
            {
                return NotFound();
            }
            return workExperience;
        }

        [HttpPost]
        public ActionResult AddWorkExperience([FromBody] WorkExperience workExperience)
        {
            _workExperienceRepository.AddWorkExperience(workExperience);
            return CreatedAtAction(nameof(GetWorkExperienceById), new { id = workExperience.ID }, workExperience);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateWorkExperience(int id, [FromBody] WorkExperience workExperience)
        {
            if (id != workExperience.ID)
            {
                return BadRequest();
            }

            _workExperienceRepository.UpdateWorkExperience(workExperience);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteWorkExperience(int id)
        {
            _workExperienceRepository.DeleteWorkExperience(id);
            return NoContent();
        }
    }
}
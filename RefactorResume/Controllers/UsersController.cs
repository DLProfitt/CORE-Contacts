using Microsoft.AspNetCore.Mvc;
using RefactorResume.Data;
using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers() // New action
        {
            return _userRepository.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _userRepository.UpdateUser(user);
            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}

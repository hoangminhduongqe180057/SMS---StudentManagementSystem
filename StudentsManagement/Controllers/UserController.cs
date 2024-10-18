using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Data;
using StudentsManagement.Services;
using StudentsManagement.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<List<ApplicationUser>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUserById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var result = await _userRepository.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }

            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userRepository.DeleteAsync(id);
            if (!result.Succeeded)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }

            return NoContent();
        }
    }
}


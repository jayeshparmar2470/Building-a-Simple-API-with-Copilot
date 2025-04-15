using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Copilot helped create a static list of users for demonstration purposes.
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        };

        // Copilot generated the GET endpoint to retrieve a list of users.
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Copilot suggested adding error handling to manage exceptions.
                return StatusCode(500, new { Message = "An error occurred while retrieving users", Details = ex.Message });
            }
        }

        // Copilot generated the GET endpoint to retrieve a specific user by ID.
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Copilot suggested adding error handling for non-existent users.
                return NotFound(new { Message = "User not found" });
            }
            return Ok(user);
        }

        // Copilot generated the POST endpoint to add a new user.
        [HttpPost]
        public ActionResult<User> AddUser([FromBody] User user)
        {
            try
            {
                // Copilot suggested adding validation for user input fields.
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                user.Id = users.Max(u => u.Id) + 1;
                users.Add(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                // Copilot suggested adding error handling to manage exceptions.
                return StatusCode(500, new { Message = "An error occurred while adding the user", Details = ex.Message });
            }
        }

        // Copilot generated the PUT endpoint to update an existing user's details.
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                // Copilot suggested adding validation for user input fields.
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    // Copilot suggested adding error handling for non-existent users.
                    return NotFound(new { Message = "User not found" });
                }
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                return NoContent();
            }
            catch (Exception ex)
            {
                // Copilot suggested adding error handling to manage exceptions.
                return StatusCode(500, new { Message = "An error occurred while updating the user", Details = ex.Message });
            }
        }

        // Copilot generated the DELETE endpoint to remove a user by ID.
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Copilot suggested adding error handling for non-existent users.
                return NotFound(new { Message = "User not found" });
            }
            users.Remove(user);
            return NoContent();
        }
    }

    // Copilot helped define the User class to represent user data.
    public class User
    {
        public int Id { get; set; }

        // Copilot suggested adding validation attributes to ensure valid user data.
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs.User;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService userService)
        {
            _UserService = userService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await _UserService.GetAllUserAsync();

            return Ok(users);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDTO>> CreateUser(UserCreateDTO user)
        {
            var userId = await _UserService.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetAllUsers), new { id = userId});

        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var success  = await _UserService.DeleteUserAsync(id);

            if (!success)
                return NotFound();


            return NoContent();
        }

    }
}

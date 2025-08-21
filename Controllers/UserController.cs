using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturangAPI.DTOs.User;
using ResturangAPI.Service.IService;

namespace ResturangAPI.Controllers
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
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await _UserService.GetAllUserAsync();
           
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserCreateDTO user)
        {
            var userId = await _UserService.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetAllUsers), new { id = userId}); 
            
        }

    }
}

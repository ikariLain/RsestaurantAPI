using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RestaurantAPI.Data;
using RestaurantAPI.DTOs;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserRegisterDTO newUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == newUser.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already in use.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            var newAccount = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Role = "User",
                PasswordHash = passwordHash
            };

            _context.Users.Add(newAccount);
            _context.SaveChanges();

            return Ok();
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUser)
        {

            var user = _context.Users.FirstOrDefault(u => u.Email == loginUser.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid email or password.");
            }

            var PasswordMatch = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash);

            if (PasswordMatch)
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = GenerateJwtToken(user);

            return Ok(new {token});
        }
        //TODO: Change later
        private string GenerateJwtToken(User user)
        {
           var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}" ),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            });

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
               
            };

            var token = tokenHandler.CreateToken(TokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}

using jobify_Backend.Data;
using jobify_Backend.Dto.UserDtos;
using jobify_Backend.Models;
using jobify_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jobify_Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _token;

        public LoginController(AppDbContext context,TokenService token)
        {
           
            _context = context;
            _token = token;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName.ToLower() == loginDto.UserName.ToLower());

            if (currentUser == null) return NotFound("User name not found");

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, currentUser.Password);
            if (!isPasswordValid) return BadRequest("The password does not match!");

            if (currentUser != null && isPasswordValid)
            {
                var token = _token.GenerateToken(currentUser);
                return Ok(new {token,currentUser.UserId,currentUser.Role});
            }
            return NotFound("User Not Found");
            
        }


        [Authorize]
        [HttpGet("verify-token")]
        public IActionResult VerifyToken()
        {
            return Ok("User Authorized");
        }


    }
}

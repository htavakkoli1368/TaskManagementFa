using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementFa.DTOs;

namespace TaskManagementFa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto request)
        {
            if (request.UserName != "admin" || request.Password != "123456")
                return Unauthorized();
            var jwtKey = _configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new System.Security.Claims.Claim(ClaimTypes.Name, request.UserName) ,       
                new System.Security.Claims.Claim(ClaimTypes.Role, "admin")       
                   
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credential
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(tokenString);
        }
    }
}

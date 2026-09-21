using JwtAuthDotnet9.Entities;
using JwtAuthDotnet9.Models;
using JwtAuthDotnet9.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JwtAuthDotnet9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);

            if (user== null)
            {
                return BadRequest("username already exists");
            }

            return Ok(user);
        }

        [HttpPost("login")]

        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var token = await authService.loginAsync(request);
            if (token == null)
            {
                return BadRequest("invalid username or password" ); 
            }

            return Ok(token);
        }

       }  
}

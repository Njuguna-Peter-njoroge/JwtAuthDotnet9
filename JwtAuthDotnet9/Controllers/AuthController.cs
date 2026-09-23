using JwtAuthDotnet9.Entities;
using JwtAuthDotnet9.Models;
using JwtAuthDotnet9.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var result = await authService.loginAsync(request);
            if (result == null)
            {
                return BadRequest("invalid username or password" ); 
            }

            return Ok(result);


        }

        [HttpPost("refreshToken")]
public async Task<ActionResult<TokenResponseDto>> RefreshToken(refreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokenAsync(request); 

            if(result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return Unauthorized("invalid refresh token");
            }

            return Ok(result);
        }
        [Authorize]
        [HttpGet]

        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("you are Authenicated");
            }


        [Authorize(Roles ="Admin")]
        [HttpGet("Admin-only")]

        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("you are ");
        }

    }
}

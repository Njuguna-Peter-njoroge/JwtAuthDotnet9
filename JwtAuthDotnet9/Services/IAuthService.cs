using JwtAuthDotnet9.Entities;
using JwtAuthDotnet9.Models;

namespace JwtAuthDotnet9.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> loginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(refreshTokenRequestDto request);
    }
}

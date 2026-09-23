namespace JwtAuthDotnet9.Models
{
    public class refreshTokenRequestDto
    {
        public Guid UserId  { get; set; }
        public required string    RefreshToken { get; set; }
    }
}

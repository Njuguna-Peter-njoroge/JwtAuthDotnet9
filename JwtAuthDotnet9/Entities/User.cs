namespace JwtAuthDotnet9.Entities
{
    public class User
    {
        public Guid id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

    }
}

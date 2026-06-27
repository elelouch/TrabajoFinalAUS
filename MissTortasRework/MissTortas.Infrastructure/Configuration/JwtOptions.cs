namespace MissTortas.Infrastructure.Configuration
{
    public class JwtOptions
    {
        public string Key { get; init; } = null!;
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
        public int ExpirationMinutesAccessToken { get; init; }
        public int ExpirationMinutesRefreshToken { get; init; }
    }
}

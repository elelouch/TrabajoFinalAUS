namespace Misstortas.Frontend.Services.Auth
{
    public class RefreshResponseDTO
    {
        public required string AccessToken { get; init; }
        public required string RefreshToken { get; init; }
    }
}
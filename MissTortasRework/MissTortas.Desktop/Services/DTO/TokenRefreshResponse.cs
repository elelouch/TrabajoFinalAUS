namespace MissTortas.Desktop.Services.DTO
{
    public class TokenRefreshResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}

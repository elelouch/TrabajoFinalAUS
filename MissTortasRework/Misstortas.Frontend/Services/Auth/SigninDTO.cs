namespace Misstortas.Frontend.Services.Auth
{
    public class SigninDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
    }
}

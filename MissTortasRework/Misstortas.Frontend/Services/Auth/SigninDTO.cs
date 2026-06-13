namespace Misstortas.Frontend.Services.Auth
{
    public class SigninDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Result { get; set; } = string.Empty;
    }
}

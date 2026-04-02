using Microsoft.AspNetCore.Identity;

namespace MissTortas.Services.DTO.Security
{
    public class LoginUserResultDTO
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public required SignInResult SignInResult { get; set; }
    }
}

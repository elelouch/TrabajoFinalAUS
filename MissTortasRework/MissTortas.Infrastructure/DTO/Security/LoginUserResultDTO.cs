using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.DTO.Security
{
    public class LoginUserResultDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public required SignInResult SignInResult { get; set; }
    }
}

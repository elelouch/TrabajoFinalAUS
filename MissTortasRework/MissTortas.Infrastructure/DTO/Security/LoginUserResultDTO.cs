using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.DTO.Security
{
    public class LoginUserResultDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public required SignInResult SignInResult { get; set; }
    }
}

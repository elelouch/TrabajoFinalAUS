using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.DTO.Security
{
    public class SignUpUserResultDTO
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IdentityResult IdentityResult { get; set; } = default!;
    }
}

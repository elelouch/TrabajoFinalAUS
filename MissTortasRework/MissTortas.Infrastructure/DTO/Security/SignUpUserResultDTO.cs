using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.DTO.Security
{
    public class SignUpUserResultDTO
    {
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public IdentityResult? IdentityResult { get; set; }
    }
}

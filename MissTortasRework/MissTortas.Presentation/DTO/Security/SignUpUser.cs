using Microsoft.AspNetCore.Identity;

namespace MissTortas.Presentation.DTO.Security
{
    public class SignUpUser
    {
        public string Username { get; set; } = string.Empty;
        public IdentityResult? Result { get; set; }
    }
}
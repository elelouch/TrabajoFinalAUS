using Microsoft.AspNetCore.Identity;

namespace MissTortas.View.DTO.Security
{
    public class SignUpUser
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace MissTortas.Engine.DTO.User
{
    public class UserRegistrationDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

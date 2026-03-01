using FluentValidation;

namespace MissTortas.Presentation.DTO.Security
{
    public class CreateUser
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}

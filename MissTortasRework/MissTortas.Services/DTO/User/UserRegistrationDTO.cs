using System.ComponentModel.DataAnnotations;

namespace MissTortas.Services.DTO.User
{
    public class UserRegistrationDTO
    {
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password required")]
        [MaxLength()]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        public string Password { get; set; } = string.Empty;
    }
}

namespace MissTortas.View.DTO.Security
{
    public class MissTortasRegisterRequest
    {
        public required string Email { get; init; }
        public required string Username { get; init; }
        public required string Password { get; init; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}

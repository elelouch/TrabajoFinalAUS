namespace MissTortas.Desktop.Services.UserService
{
    public class UserModificationDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string[] Roles { get; set; } = [];
        public bool Enabled { get; set; }
        public string NewPassword { get; set; } = string.Empty;
    }
}

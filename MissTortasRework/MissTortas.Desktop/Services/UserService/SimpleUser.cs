namespace MissTortas.Desktop.Services.UserService
{
    public class SimpleUser
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool Enabled { get; set; }
        public string Email { get; set; } = string.Empty;
        public string[] Roles { get; set; } = [];
    }
}

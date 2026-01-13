using MissTortasEngine.Model.Security.Permissions;

namespace MissTortasEngine.Model.Security.User
{
    public class UserBase
    {
        public long Id { get; set; }
        public Guid UUID { get; set; } = System.Guid.NewGuid();
        public required string Username { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public List<Role>? Roles { get; set; }
    }
}

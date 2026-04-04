namespace MissTortas.Presentation.DTO.Security
{
    public class UserModification
    {
        public string UserId { get; set; } = string.Empty;
        public bool? Enabled { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<string>? Roles { get; set; }
    }
}

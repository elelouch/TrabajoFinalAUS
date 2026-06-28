namespace MissTortas.Desktop.Services.AuthService
{
    public class UserMetadata
    {
        public IEnumerable<string> Roles { get; set; } = [];
        public long UserId { get; set; }
        public string AppUserId { get; set; } = "";
        public string Username { get; set; } = "";
        public required UserCapabilities Capabilities { get; set; } = default!;
    }
}

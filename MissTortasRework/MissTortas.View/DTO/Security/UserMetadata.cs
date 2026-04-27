namespace MissTortas.View.DTO.Security
{
    public class UserMetadata
    {
        public IEnumerable<string> Roles { get; set; } = [];
        public long UserId { get; set; }
        public string AppUserId { get; set; }
        public UserCapabilities Capabilities { get; set; } = default!;
    }
}

namespace MissTortas.Services.DTO.Security
{
    public class CurrentUserDTO
    {
        public long Id { get; init; }
        public string Username { get; init; } = "";
        public HashSet<string> Roles { get; init; } = [];
        public HashSet<string> Permissions { get; init; } = [];
    }
}

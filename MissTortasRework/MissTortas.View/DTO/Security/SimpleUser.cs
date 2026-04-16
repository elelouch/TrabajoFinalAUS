namespace MissTortas.View.DTO.Security
{
    public class SimpleUser
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
    }
}

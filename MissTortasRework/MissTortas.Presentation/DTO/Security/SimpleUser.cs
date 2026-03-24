namespace MissTortas.Presentation.DTO.Security
{
    public class SimpleUser
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
    }
}

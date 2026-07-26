namespace MissTortas.Infrastructure.DTO.Security
{
    public class AssignPermissionToUserDTO
    {
        public string UserId { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = [];
    }
}

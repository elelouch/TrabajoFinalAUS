namespace MissTortas.Infrastructure.DTO.Security
{
    public class AssignPermissionsToRoleDTO
    {
        public long RoleId { get; set; }
        public List<string> Permissions { get; set; } = [];
    }
}

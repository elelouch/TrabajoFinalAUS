namespace MissTortas.Infrastructure.DTO.Security
{
    public class ModifyRoleDTO
    {
        public string RoleId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = [];
    }
}

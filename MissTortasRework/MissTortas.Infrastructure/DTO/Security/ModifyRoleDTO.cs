namespace MissTortas.Infrastructure.DTO.Security
{
    public class ModifyRoleDTO
    {
        public long RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = [];
    }
}

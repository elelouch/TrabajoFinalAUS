namespace MissTortas.Presentation.DTO.Security
{
    public class AssignPermissionToRole
    {
        public List<long> PermissionsId { get; set; } = [];
        public string RoleName { get; set; }
    }
}

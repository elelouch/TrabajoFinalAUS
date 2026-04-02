namespace MissTortas.Infrastructure.DTO.Security
{
    public class AssignPermissionsDTO
    {
        public AssignPermissionsToRoleDTO? RolePermissions { get; set; }
        public AssignPermissionToUserDTO? UserPermissions { get; set; }
    }
}

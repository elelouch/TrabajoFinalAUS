namespace MissTortas.Infrastructure.DTO.Security
{
    public class AssignPermissionsDTO
    {
        public ModifyRoleDTO? RolePermissions { get; set; }
        public AssignPermissionToUserDTO? UserPermissions { get; set; }
    }
}

namespace MissTortas.Data.Entity.Security.Permissions
{
    public class PermissionRole : Permission
    {
        public RolePermission RolePermission { get; set; }
    }
    public enum RolePermission
    {
        AssociateRole = 1,
        DeassociateRole = 2,
        ViewRoles = 3,
        CreateRole = 4,
        RemoveRole = 5
    }
}

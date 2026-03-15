namespace MissTortas.Data.Entity.Security.Permissions
{
    public class RolePermission : Permission
    {
        public RolePermissionEnum Value { get; set; }
    }
    public enum RolePermissionEnum
    {
        AssignClaim,
        ViewAll,
        ViewSelf
    }
}

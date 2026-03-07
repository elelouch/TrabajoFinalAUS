namespace MissTortas.Data.Entity.Security.Permissions
{
    public class PermissionUser : Permission
    {
        public UserPermission UserPermisison { get; set; }
    }
    public enum UserPermission
    {
        ModifyAll = 1,
        ModifySelf = 2
    }
}

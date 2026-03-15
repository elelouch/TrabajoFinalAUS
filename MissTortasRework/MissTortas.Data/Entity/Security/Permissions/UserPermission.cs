namespace MissTortas.Data.Entity.Security.Permissions
{
    public class UserPermission : Permission
    {
        public UserPermissionEnum Value { get; set; }
    }
    public enum UserPermissionEnum
    {
        ViewAll,
        ViewSelf,
        UpdateAll,
        UpdateSelf
    }
}

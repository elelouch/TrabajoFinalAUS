namespace MissTortas.Data.Entity.Security.Permissions
{
    public class PermissionViewUser : Permission
    {
        public ViewUserPermission ViewUserPermission { get; set; }
    }
    public enum ViewUserPermission
    {
        ViewAll = 1,
        ViewClient = 2,
        ViewSelf = 3
    }  
}

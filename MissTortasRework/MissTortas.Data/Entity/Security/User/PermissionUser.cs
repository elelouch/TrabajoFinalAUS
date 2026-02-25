namespace MissTortas.Data.Entity.Security.User
{
    public class PermissionUser : Permission
    {
        public required ViewUserPermission ViewUserPermission { get; set; }
    }
}

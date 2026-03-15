namespace MissTortas.Data.Entity.Security.Permissions
{
    public class ClaimPermission : Permission
    {
        public ClaimPermissionEnum Value { get; set; }
    }
    public enum ClaimPermissionEnum
    {
        ViewAll
    }
}

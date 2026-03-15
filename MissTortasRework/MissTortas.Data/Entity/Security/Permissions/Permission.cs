namespace MissTortas.Data.Entity.Security.Permissions
{
    public abstract class Permission
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

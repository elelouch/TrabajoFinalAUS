namespace MissTortas.Domain.Security.Users
{
    public class Role
    {
        public long RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; } = [];
    }
}

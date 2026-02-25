using MissTortas.Data.Entity.Security.User;

namespace MissTortas.Data.Entity.Security
{
    public abstract class Permission
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<ApplicationUser> Users { get; set; } = [];
        public IEnumerable<ApplicationRole> Roles { get; set; } = [];
    }
}

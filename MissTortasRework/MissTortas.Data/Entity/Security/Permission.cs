using MissTortas.Data.Entity.Security.User;

namespace MissTortas.Data.Entity.Security
{
    public abstract class Permission
    {
        public long Id { get; set; }
        public virtual IEnumerable<ApplicationRole> Roles { get; set; } = [];
    }
}

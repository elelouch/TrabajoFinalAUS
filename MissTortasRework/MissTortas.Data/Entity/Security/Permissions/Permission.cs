using System.Security.Claims;

namespace MissTortas.Data.Entity.Security.Permissions
{
    public abstract class Permission
    {
        public long Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; } = string.Empty;

        public abstract Claim AsClaim();
    }
}

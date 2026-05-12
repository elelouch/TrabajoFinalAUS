using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Security.Users
{
    public class Role
    {
        public long RoleId { get; set; }
        public long SubjectId { get; set; }
        public Subject Subject { get; set; } = default!;
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; } = [];
    }
}

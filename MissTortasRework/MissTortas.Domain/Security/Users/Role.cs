using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Security.Users
{
    public class Role : Subject
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; } = [];
    }
}

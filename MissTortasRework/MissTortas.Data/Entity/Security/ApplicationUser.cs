using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security
{
    public class ApplicationUser : IdentityUser<long>
    {
        public Guid Guid { get; set; }
        public List<ApplicationRole>? Roles { get; set; }
    }
}

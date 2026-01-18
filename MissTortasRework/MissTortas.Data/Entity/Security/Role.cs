using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security
{
    public class Role: IdentityRole
    {
        public DateTime LastTimeModified { get; set; }
        public bool Deleted { get; set; }
    }
}

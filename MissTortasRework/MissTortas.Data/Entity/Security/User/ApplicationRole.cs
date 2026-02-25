using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationRole: IdentityRole<long>
    {
        public DateTime LastTimeModified { get; set; }
        public bool Deleted { get; set; }
    }
}

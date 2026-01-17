using Microsoft.AspNetCore.Identity;

namespace MissTortas.Models.Security.Permissions
{
    public class Role : IdentityRole<long>
    {
        public DateTime LastTimeModified { get; set; }
        public bool Deleted { get; set; }
    }
}

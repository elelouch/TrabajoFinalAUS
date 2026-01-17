using MissTortas.Models.Product;

namespace MissTortas.Models.Security.Permissions
{
    public class RoleCategoryPermission
    {
        public Permission Permission { get; set; }
        public required Role Role { get; set; }
        public required Category Category { get; set; }
    }
}

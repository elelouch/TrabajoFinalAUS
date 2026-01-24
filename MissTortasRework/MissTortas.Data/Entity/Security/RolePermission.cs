using MissTortas.Data.Entity.Products;

namespace MissTortas.Data.Entity.Security
{
    public class RoleCategoryPermission
    {
        public Permission Permission { get; set; }
        public required ApplicationRole Role { get; set; }
        public required Category Category { get; set; }
    }
}

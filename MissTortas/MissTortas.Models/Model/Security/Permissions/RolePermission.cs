using MissTortas.Models.Model.Product;

namespace MissTortas.Models.Model.Security.Permissions
{
    public class RoleCategoryPermission
    {
        public Permission Permission { get; set; }
        public required Role Role { get; set; }
        public required Category Category { get; set; }
    }
}

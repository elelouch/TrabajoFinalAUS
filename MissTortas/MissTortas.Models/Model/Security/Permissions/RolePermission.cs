using MissTortasEngine.Model.Product;

namespace MissTortasEngine.Model.Security.Permissions
{
    public class RoleCategoryPermission
    {
        public Permission Permission { get; set; }
        public required Role Role { get; set; }
        public required Category Category { get; set; }
    }
}

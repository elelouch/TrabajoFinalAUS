using MissTortas.Data.Entity.Security.User;

namespace MissTortas.Data.Entity.Security
{
    public class Permission
    {
        public static readonly IEnumerable<Permission> permissions =
            [
                new(nameof(ViewUserPermission), ViewUserPermission.ViewSelf.ToString()),
                new(nameof(ViewUserPermission), ViewUserPermission.ViewClient.ToString()),
                new(nameof(ViewUserPermission), ViewUserPermission.ViewAll.ToString()),
                new(nameof(RolePermission), RolePermission.AssociateRole.ToString()),
                new(nameof(RolePermission), RolePermission.DeassociateRole.ToString()),
                new(nameof(RolePermission), RolePermission.CreateRole.ToString()),
                new(nameof(RolePermission), RolePermission.RemoveRole.ToString()),
                new(nameof(RolePermission), RolePermission.ViewRoles.ToString()),
                new(nameof(CreateOrderPermission), CreateOrderPermission.CreateOrder.ToString()),
                new(nameof(CreateOrderPermission), CreateOrderPermission.CreateOrderOBO.ToString())
            ];
        public long Id { get; set; }
        public virtual List<ApplicationRole> Roles { get; set; } = [];
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public Permission() { }
        public Permission(string typeName, string name)
        {
            Name = name;
            Type = typeName;
        }
    }

    public enum CreateOrderPermission
    {
        CreateOrder,
        CreateOrderOBO
    }
    public enum ViewUserPermission
    {
        ViewAll,
        ViewClient,
        ViewSelf
    }
    public enum RolePermission
    {
        AssociateRole,
        DeassociateRole,
        ViewRoles,
        CreateRole,
        RemoveRole
    }
}

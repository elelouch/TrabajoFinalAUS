using System.Collections.ObjectModel;

namespace MissTortas.Infrastructure.Security.Permissions
{
    public readonly record struct Permission(string Code)
    {
        public override string ToString() => Code;
        public static readonly Permission ReadAllUser = new("read:user:all");
        public static readonly Permission ReadSelfUser = new("read:user:self");
        public static readonly Permission UpdateAllUser = new("update:user:all");
        public static readonly Permission UpdateSelfUser = new("update:user:self");
        public static readonly Permission DeleteUser = new("delete:user");
        public static readonly Permission ReadPermissions = new("read:permissions");
        public static readonly Permission AssignPermissions = new("assign:permissions");
        public static readonly Permission ReadRoles = new("read:roles");
        public static readonly Permission PlaceOrders = new("place:orders");
        public static readonly Permission ManageOrders = new("manage:orders");
        public static readonly Permission ManageProducts = new("manage:products");
        public static readonly Permission ManagePayments = new("manage:payments");
        public static readonly ReadOnlyCollection<Permission> SecurityPermissions =
            new([
                ReadAllUser,
                UpdateAllUser,
                DeleteUser,
                ReadPermissions,
                AssignPermissions,
                ReadRoles
            ]);
        public static readonly ReadOnlyCollection<Permission> OrderPermissions = new([
            ManageOrders,
            PlaceOrders
        ]);

        public static readonly ReadOnlyCollection<Permission> ProductPermissions = new([
            ManageProducts
        ]);

        public static readonly ReadOnlyCollection<Permission> PaymentPermissions = new([
            ManageProducts
        ]);

        public static readonly List<Permission> allPermissionList =
        [
                ReadAllUser,
                ReadSelfUser,
                UpdateAllUser,
                UpdateSelfUser,
                DeleteUser,
                ReadPermissions,
                AssignPermissions,
                ReadRoles,
                PlaceOrders,
                ManageOrders,
                ManageProducts,
                ManagePayments
        ];

        public static ReadOnlyCollection<Permission> All { get => allPermissionList.AsReadOnly(); }
        public static readonly string ClaimName = "permissions";
    }
}

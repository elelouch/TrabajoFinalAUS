using System.Collections.ObjectModel;

namespace MissTortas.Data.Entity.Security.Permissions
{
    public readonly record struct Permission(string Name)
    {
        public override string ToString() => Name;
        public static readonly Permission ReadAllUser = new("read:user:all");
        public static readonly Permission ReadSelfUser = new("read:user:self");
        public static readonly Permission UpdateAllUser = new("update:user:all");
        public static readonly Permission UpdateSelfUser = new("update:user:self");
        public static readonly Permission DeleteUser = new("delete:user");
        public static readonly Permission ReadPermissions = new("read:permissions");
        public static readonly Permission AssignPermissions = new("assign:permissions");

        private static readonly List<Permission> allPermissionList =
        [
                ReadAllUser,
                ReadSelfUser,
                UpdateAllUser,
                UpdateSelfUser,
                DeleteUser
        ];

        public static ReadOnlyCollection<Permission> All { get => allPermissionList.AsReadOnly(); }
        public static readonly string ClaimName = "permissions";
    }
}

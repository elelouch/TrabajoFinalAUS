using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Infrastructure.Security.Requirements;

namespace MissTortas.Infrastructure.Security.Constants
{
    public static class PermissionConstants
    {
        public static PermissionRequirement ReadUsers { get; set; } = new(
            [
                Permission.ReadSelfUser,
                Permission.ReadAllUser
            ]
        );
        public static PermissionRequirement UpdateUsers { get; set; } = new(
            [
                Permission.UpdateSelfUser,
                Permission.UpdateAllUser
            ]
);

    }

}

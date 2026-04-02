using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Services.Security.Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Constants
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

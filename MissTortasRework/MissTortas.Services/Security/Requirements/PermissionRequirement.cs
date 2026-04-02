using Microsoft.AspNetCore.Authorization;
using MissTortas.Infrastructure.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.Security.Requirements
{
    public class PermissionRequirement(List<Permission> permissionsRequired) : IAuthorizationRequirement
    {
        public List<Permission> PermissionsRequired { get; set; } = permissionsRequired;
    }

}

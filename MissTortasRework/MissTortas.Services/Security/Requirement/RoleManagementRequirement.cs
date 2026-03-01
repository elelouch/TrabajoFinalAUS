using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Requirement
{
    public class RoleManagementRequirement(IEnumerable<RolePermission> rolePermissions) : IAuthorizationRequirement 
    {
        public IEnumerable<RolePermission> RolePermissions { get; set; } = rolePermissions;
    }
}

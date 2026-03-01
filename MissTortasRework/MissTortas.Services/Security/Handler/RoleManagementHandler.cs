using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Interfaces;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Security.Requirement;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Handler
{
    public class RoleManagementHandler(ISecurityRepository repository) : AuthorizationHandler<RoleManagementRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleManagementRequirement requirement)
        {
            var permissionsName = Enum.GetNames<RolePermission>();
            repository.FindAllPermissionAsync()
        }
    }
}

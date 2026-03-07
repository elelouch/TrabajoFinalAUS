using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Requirement
{
    public class UserRequirement(UserPermission requiredPermission) : IAuthorizationRequirement
    {
        public UserPermission RequiredPermission { get; } = requiredPermission;
    }
}

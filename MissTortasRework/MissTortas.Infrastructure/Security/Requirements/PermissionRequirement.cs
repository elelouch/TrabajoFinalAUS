using Microsoft.AspNetCore.Authorization;
using MissTortas.Infrastructure.Security.Permissions;

namespace MissTortas.Services.Security.Requirements
{
    public class PermissionRequirement(List<Permission> permissionsRequired) : IAuthorizationRequirement
    {
        public List<Permission> PermissionsRequired { get; set; } = permissionsRequired;
    }

}

using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Mappings.Interfaces;
using MissTortas.Infrastructure.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Infrastructure.Mappings
{
    public class UserMapper : IUserMapper
    {
        public UserMetadata ClaimsPrincipalToUserMetadata(ClaimsPrincipal principal)
        {
            var permissions = principal
                .FindAll(c => c.Type == Permission.ClaimName)
                .Select(c => c.Value);
            var userMetadata = new UserMetadata
            {
                AppUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
                Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value),
                Capabilities = MapCapabilities(permissions)
            };
            return userMetadata;
        }

        private static UserCapabilities MapCapabilities(IEnumerable<string> permissionsList)
        {
            var permissionsSet = new HashSet<string>(permissionsList);
            return new UserCapabilities
            {
                //CanViewUsers = permissionsSet.Contains(Permission.ReadAllUser.Code)
                CanManageSecurity = permissionsSet.Any(p => Permission.SecurityPermissions.Any(sp => sp.Code == p))
                CanManageOrders = permissionsSet.Any(p => Permission.OrderPermissions.Any(op => op.Code == p)),
                CanManageProducts = permissionsSet.Any(p => Permission.OrderPermissions.Any(pp => pp.Code == p)),
                CanManagePayments = permissionsSet.Any(p => Permission..Any(pp => pp.Code == p))
            };
        }
    }
}

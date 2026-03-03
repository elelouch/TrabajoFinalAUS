using MissTortas.Data.Entity.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security
{
    public static class PermissionFactory
    {
        public static List<Permission> GeneratePermissions()
        {
            var permissions = new List<Permission>();

            foreach(var val in Enum.GetValues<CreateOrderPermission>())
            {
                permissions.Add(new PermissionCreateOrder() 
                { 
                    Name = val.ToString(),
                    Value = (int) val
                });
            }
            foreach (var val in Enum.GetValues<ViewUserPermission>())
            {
                permissions.Add(new PermissionViewUser()
                {
                    Name = val.ToString(),
                    Value = (int)val
                });
            }

            foreach (var val in Enum.GetValues<RolePermission>())
            {
                permissions.Add(new PermissionRole()
                {
                    Name = val.ToString(),
                    Value = (int)val
                });
            }

            return permissions;
        }
    }
}

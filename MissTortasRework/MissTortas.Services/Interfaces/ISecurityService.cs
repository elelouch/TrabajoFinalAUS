using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface ISecurityService
    {
        public Task<IEnumerable<Permission>> GetAllPermissions();
        public Task CreatePermissionBulkAsync(IEnumerable<Permission> permissionBulk);
        public Task AssignPermissionBulkAsync(string roleName, IEnumerable<Permission> permissionBulk);
    }
}

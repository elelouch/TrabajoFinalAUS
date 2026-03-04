using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Services.DTO.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface ISecurityService
    {
        public Task<> SignUpUserAsyncDTO(SignUpUserDTO dto);
        public Task<IEnumerable<Permission>> GetAllPermissions();
        public Task AssignPermissionBulkAsync(string roleName, IEnumerable<Permission> permissionBulk);
        public Task AssignPermissionBulkAsync(AssignPermissionToRoleDTO dto);
        public Task ModifyUserAsync(UserModificationDTO dto);
    }
}

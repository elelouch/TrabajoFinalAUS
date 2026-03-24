using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Services.DTO.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface ISecurityService
    {
        public IEnumerable<Permission> GetAllPermissions();
        public Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        public Task<IEnumerable<ApplicationUser>> GetUsersForAsync(CurrentUserDTO user);
        public Task<LoginUserResultDTO?> SignInUserAsync(LoginUserDTO dto);
        public Task<SignUpUserResultDTO> SignUpUserAsync(SignUpUserDTO dto);
        public Task<IEnumerable<string>> GetAllRolesAsync();
        public Task AssignPermissionsToRoleAsync(AssignPermissionsToRoleDTO dto);
        public Task AssignPermissionsToUserAsync(AssignPermissionsToRoleDTO dto);
        public Task AssignPermissionsAsync(AssignPermissionsDTO dto);
        public Task ModifyUserAsync(UserModificationDTO dto);
    }
}

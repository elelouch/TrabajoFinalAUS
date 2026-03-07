using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;

namespace MissTortas.Services
{
    public class SecurityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        SignInManager<ApplicationUser> signInManager,
        ISecurityRepository securityRepository,
        ITokenGenerator tokenGenerator
        ) : ISecurityService
    {
        public async Task<LoginUserResultDTO> SignInUserAsync(LoginUserDTO request)
        {
            var user = await userManager.FindByNameAsync(request.Email) ?? throw new UserNotFoundException($"User {request.Email}not found.");
            var result = await signInManager.PasswordSignInAsync(user, request.Password, true, true);
            var dtoRet = new LoginUserResultDTO
            {
                Id = user.Id,
                Username = user.UserName!,
                AccessToken = tokenGenerator.GenerateToken(user),
                SignInResult = result
            };
            return dtoRet;
        }

        public async Task<SignUpUserResultDTO> SignUpUserAsync(SignUpUserDTO request)
        {
            var newUser = new ApplicationUser
            {
                Email = request.Username,
                UserName = request.Username,
                Guid = Guid.NewGuid(),
                EmailConfirmed = false,
                LockoutEnabled = true,
                LockoutEnd = DateTimeOffset.MaxValue
            };
            var userCreation = await userManager.CreateAsync(newUser, request.Password);
            if (!userCreation.Succeeded)
            {
                return new SignUpUserResultDTO() { IdentityResult = userCreation };
            }
            var newRoleName = $"{newUser.Id}-{newUser.UserName}";
            var trivialRole = new ApplicationRole { Trivial = true, Name = newRoleName };
            var roleCreation = await roleManager.CreateAsync(trivialRole);
            if (!roleCreation.Succeeded)
            {
                return new SignUpUserResultDTO() { IdentityResult = roleCreation };
            }
            var trivialRoleAssign = await userManager.AddToRoleAsync(newUser, newRoleName);
            if (!trivialRoleAssign.Succeeded)
            {
                return new SignUpUserResultDTO() { IdentityResult = trivialRoleAssign };
            }
            await userManager.AddToRoleAsync(newUser, ApplicationRole.UserRole.Name!);

            return new SignUpUserResultDTO() { Id = newUser.Id, Email = newUser.Email };
        }

        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            var permissions = securityRepository.GetAllPermissions();
            return await permissions.ToListAsync();
        }

        public async Task AssignPermissionBulkAsync(string roleName, IEnumerable<Permission> permissionBulk)
        {
            var role = await roleManager.FindByNameAsync(roleName) ?? throw new InvalidOperationException("Role does not exists.");
            foreach (var p in permissionBulk)
            {
                if (p.Roles.All(r => r.Id != role.Id))
                {
                    role.Permissions.Add(p);
                }
            }
            await securityRepository.SaveChangesAsync();
        }

        public async Task AssignPermissionBulkAsync(AssignPermissionToRoleDTO dto)
        {
            var allPermissions = await securityRepository.FindAllPermissionsAsync(dto.PermissionsId) ?? throw new PermissionNotFound("Couldn't found a permission");
            await AssignPermissionBulkAsync(dto.RoleName, allPermissions);
        }

        public async Task ModifyUserAsync(UserModificationDTO dto)
        {
            var user = await userManager.FindByNameAsync(dto.Username)
             ?? throw new UserNotFoundException("User not found.");

            user.Email = dto.Email;
            user.LockoutEnabled = !dto.IsEnabled;

            var updateResult = await userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to update user.");
            }

            if (!string.IsNullOrEmpty(dto.Role))
            {
                var currentRoles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, currentRoles);
                await userManager.AddToRoleAsync(user, dto.Role);
            }

            await securityRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }
    }
}

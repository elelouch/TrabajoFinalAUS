using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Mappings.Interfaces;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Services.Interfaces;
using System.Data;
using System.Security.Claims;

namespace MissTortas.Infrastructure.Security
{
    public class SecurityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenGenerator tokenGenerator,
        IRoleMapper roleMapper
        ) : ISecurityService
    {
        public async Task<LoginUserResultDTO?> SignInUserAsync(LoginUserDTO request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return null;
            }
            var userPrincipal = await signInManager.CreateUserPrincipalAsync(user);
            var dtoRet = new LoginUserResultDTO
            {
                AccessToken = await tokenGenerator.GenerateToken(userPrincipal),
                SignInResult = await signInManager.PasswordSignInAsync(user, request.Password, true, true)
            };
            return dtoRet;
        }

        public async Task<SignUpUserResultDTO> SignUpUserAsync(SignUpUserDTO request)
        {
            if (request.UserId == 0)
            {
                throw new InvalidOperationException("UserId is not valid.");
            }
            var newUser = new ApplicationUser
            {
                UserId = request.UserId,
                Email = request.Username,
                UserName = request.Username,
                EmailConfirmed = false,
                LockoutEnabled = true,
                LockoutEnd = DateTimeOffset.MaxValue
            };
            var userCreation = await userManager.CreateAsync(newUser, request.Password);
            if (!userCreation.Succeeded)
            {
                return new SignUpUserResultDTO() { IdentityResult = userCreation };
            }
            await userManager.AddToRoleAsync(newUser, UserConstants.UserRoleName);

            return new SignUpUserResultDTO() { UserId = newUser.Id, Email = newUser.Email, IdentityResult = userCreation };
        }

        public async Task ModifyUserAsync(ApplicationUserModificationDTO dto)
        {
            var user = await userManager.FindByIdAsync(dto.UserId);
            if (user is null)
            {
                return;
            }

            user.UserName = dto.Username;
            user.Email = dto.Email;
            user.LockoutEnabled = dto.IsEnabled is false;

            var updateResult = await userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to update user.");
            }

            var roles = dto.Roles;
            if (roles is not null)
            {
                await UpdateRolesAsync(user, roles);
            }
            await userManager.UpdateSecurityStampAsync(user);
        }

        private async Task UpdateRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            var difference = await FindNonExistentRolesAsync(roles);
            if (difference.Count > 0)
            {
                throw new InvalidOperationException($"Not all roles exist. Check: {string.Join(", ", difference)}");
            }

            var currentRoles = await userManager.GetRolesAsync(user);
            var rolesToAdd = roles.Except(currentRoles);
            var rolesToRemove = currentRoles.Except(roles);

            var removeResult = await userManager.RemoveFromRolesAsync(user, rolesToRemove);
            if (!removeResult.Succeeded)
            {
                var errors = string.Join(", ", removeResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }

            var addResult = await userManager.AddToRolesAsync(user, rolesToAdd);
            if (!addResult.Succeeded)
            {
                var errors = string.Join(", ", addResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
        }

        private async Task<List<string>> FindNonExistentRolesAsync(IEnumerable<string> roles)
        {
            var rolesNormalized = roles.Select(r => r.ToUpper());
            var rolesFound = await roleManager.Roles
                .Where(r => rolesNormalized.Contains(r.NormalizedName ?? ""))
                .Select(r => r.NormalizedName)
                .ToListAsync();
            var ret = rolesFound.Except(rolesNormalized);
            return [.. ret];
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await userManager.Users.Include(u => u.User).ThenInclude(user => user.Roles).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetUserByIdAsync(string appUserId)
        {
            return await userManager
                .Users
                .Include(u => u.User)
                .ThenInclude(ur => ur.Roles)
                .Where(u => u.UserName == appUserId)
                .ToListAsync();
        }

        public async Task AssignPermissionsToRoleAsync(AssignPermissionsToRoleDTO dto)
        {
            var role = await roleManager.FindByIdAsync(dto.RoleId.ToString());
            if (role is null)
            {
                return;
            }
            var permissionsAsked = dto.Permissions;
            PermissionsExist(permissionsAsked);
            await UpdatePermissionsAsync(role, permissionsAsked);
        }

        private async Task UpdatePermissionsAsync(ApplicationRole role, IEnumerable<string> permissions)
        {
            var currentClaims = await roleManager.GetClaimsAsync(role);
            var currentRolePermissions = currentClaims.Where(c => c.Type == Permission.ClaimName).Select(c => c.Value);
            var permissionsToAdd = permissions.Except(currentRolePermissions);
            var permissionsToRemove = currentRolePermissions.Except(permissions);
            foreach (var item in permissionsToAdd)
            {
                await roleManager.AddClaimAsync(role, new Claim(Permission.ClaimName, item));
            }
            foreach (var item in permissionsToRemove)
            {
                await roleManager.RemoveClaimAsync(role, new Claim(Permission.ClaimName, item));
            }
        }
        private static void PermissionsExist(IEnumerable<string> permissions)
        {
            var permissionsDiff = permissions.Except(Permission.All.Select(p => p.Code));
            if (permissionsDiff.Any())
            {
                throw new InvalidOperationException($"The following permissions don't exist {string.Join(",", permissionsDiff)}");
            }
        }

        public async Task<IEnumerable<SimpleRoleDTO>> GetAllRolesAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return roleMapper.RoleToSimpleDTO(roles);
        }

        public async Task<RoleDTO?> GetRoleAsync(string name)
        {
            var role = await roleManager.FindByNameAsync(name);
            if (role is null)
            {
                return null;
            }
            var permissions = (await roleManager.GetClaimsAsync(role))
                .Where(c => c.Type == Permission.ClaimName)
                .Select(c => new Permission { Code = c.Type });

            return roleMapper.RoleWithPermissionsToDTO(role, permissions);
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return Permission.All;
        }

        public Task AssignPermissionsToUserAsync(AssignPermissionsToRoleDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task AssignPermissionsAsync(AssignPermissionsDTO dto)
        {
            throw new NotImplementedException();
        }

    }
}

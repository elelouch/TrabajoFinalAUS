using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper.Interfaces;
using MissTortas.Services.Security.Constants;
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
            var user = await userManager.Users.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role.RoleClaims)
                .Include(u => u.Claims)
                .Where(u => u.UserName == request.Username)
                .SingleOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var result = await signInManager.PasswordSignInAsync(user, request.Password, true, true);
            var dtoRet = new LoginUserResultDTO
            {
                Id = user.Id,
                Username = user.UserName!,
                AccessToken = await tokenGenerator.GenerateToken(user),
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
            await userManager.AddToRoleAsync(newUser, ApplicationRole.UserRole.Name!);

            return new SignUpUserResultDTO() { Id = newUser.Id, Email = newUser.Email };
        }

        public async Task ModifyUserAsync(UserModificationDTO dto)
        {
            var user = await userManager.FindByIdAsync(dto.UserId.ToString()) ?? throw new UserNotFoundException("User not found.");
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
            return await userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
        }

        public async Task AssignPermissionsToRoleAsync(AssignPermissionsToRoleDTO dto)
        {
            var role = await roleManager.FindByIdAsync(dto.RoleId.ToString()) ?? throw new RoleNotFound("Role not found.");
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

        public async Task<RoleDTO> GetRoleAsync(long id)
        {
            var role = await roleManager.Roles
                .Include(r => r.RoleClaims)
                .Where(r => r.Id == id)
                .SingleAsync();
            return roleMapper.RoleToDTO(role);
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

        public async Task<IEnumerable<ApplicationUser>> GetUsersForAsync(CurrentUserDTO user)
        {
            var readAllUserPermission = Permission.ReadAllUser.Code;
            var canSeeAllUsers = user.Permissions.Any(p => readAllUserPermission == p);
            if (canSeeAllUsers)
            {
                return await GetAllUsersAsync();
            }
            var currentUser = await userManager.FindByNameAsync(user.Username);
            return currentUser == null ? throw new UserNotFoundException($"User {user.Id} - {user.Username} not found.") : [currentUser];
        }

        public async Task<IEnumerable<Claim>> GetUserClaimsAsync(long userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString()) ?? throw new UserNotFoundException("User not found."); ;
            var roleClaims = user.UserRoles
                .SelectMany(ur => ur.Role.RoleClaims)
                .Select(rc => rc.ToClaim());
            var userClaims = user.Claims.Select(userClaim => userClaim.ToClaim());
            var allClaims = roleClaims.Concat(userClaims).Distinct();
            return allClaims;
        }

    }
}

using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Security.Constants;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MissTortas.Services
{
    public class SecurityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenGenerator tokenGenerator
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
            user.LockoutEnabled = !(dto.IsEnabled ?? true);
            var updateResult = await userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to update user.");
            }

            var roles = dto.Roles;
            if (roles is not null)
            {
                var difference = await FindNonExistentRoles(roles);
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
        }

        private async Task<List<string>> FindNonExistentRoles(IEnumerable<string> roles)
        {
            var rolesFound = await roleManager.Roles
                .Where(r => roles.Contains(r.Name ?? ""))
                .Select(r => r.Name)
                .ToListAsync();
            var ret = roles.Except(rolesFound);
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
            var permissionsDiff = Permission.All.Select(p => p.Name).Except(permissionsAsked);
            if (permissionsDiff.Any())
            {
                throw new InvalidOperationException($"The following permissions don't exist {string.Join(",", permissionsDiff)}");
            }
            permissionsAsked.ForEach(async pAsked => await roleManager.AddClaimAsync(role, new Claim(Permission.ClaimName, pAsked)));
        }

        public async Task<IEnumerable<string>> GetAllRolesAsync()
        {
            return await roleManager.Roles.Select(r => r.Name!).ToListAsync();
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
            if (user.Permissions.Any(p => Permission.ReadAllUser.Name == p))
            {
                return await GetAllUsersAsync();
            }
            var currentUser = await userManager.FindByNameAsync(user.Username);
            return currentUser == null ? throw new UserNotFoundException($"User {user.Id} - {user.Username} not found.") : [currentUser];
        }
    }
}

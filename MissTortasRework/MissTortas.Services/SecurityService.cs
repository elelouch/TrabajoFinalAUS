using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;
using MissTortas.Services.Security.Constants;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<LoginUserResultDTO?> SignInUserAsync(LoginUserDTO request)
        {
            var user = await userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return null;
            }
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
            await userManager.AddToRoleAsync(newUser, ApplicationRole.UserRole.Name!);

            return new SignUpUserResultDTO() { Id = newUser.Id, Email = newUser.Email };
        }

        public async Task ModifyUserAsync(UserModificationDTO dto)
        {
            var user = await userManager.FindByNameAsync(dto.Username) ?? throw new UserNotFoundException("User not found.");
            var roles = dto.Roles;
            if(roles.Any())
            {
                var difference = await FindNonExistentRoles(roles);
                if (difference.Count > 0)
                {
                    throw new InvalidOperationException($"Not all roles exist. Check: {string.Join(", ", difference)}");
                }

                var currentRoles = await userManager.GetRolesAsync(user);
                var removeResult = await userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                {
                    var errors = string.Join(", ", removeResult.Errors.Select(e => e.Description));
                    throw new InvalidOperationException(errors);
                }

                var addResult = await userManager.AddToRolesAsync(user, roles);
                if (!addResult.Succeeded)
                {
                    var errors = string.Join(", ", addResult.Errors.Select(e => e.Description));
                    throw new InvalidOperationException(errors);
                }
            }

            user.Email = dto.Email;
            user.LockoutEnabled = !(dto.IsEnabled ?? true);
            var updateResult = await userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to update user.");
            }
        }

        private async Task<List<string>> FindNonExistentRoles(IEnumerable<string> roles)
        {
            var rolesFound = await roleManager.Roles
                .Where(r => roles.Contains(r.Name ?? ""))
                .Select(r => r.Name)
                .ToListAsync();
            var sape = roles.Except(rolesFound);
            return [.. sape];
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
        }

        public async Task AssignPermissionsAsync(AssignPermissionsToRoleDTO dto)
        {
            var role = await roleManager.FindByIdAsync(dto.RoleId.ToString()) ?? throw new RoleNotFound("Role not found.");
            var currentRoleClaims = await roleManager.GetClaimsAsync(role);
            var permissionsIdAsked = dto.Permissions;
            var permissionsAsked = await securityRepository.GetAllPermissions().Where(p => permissionsIdAsked.Contains(p.Id)).ToListAsync();

            foreach (var perm in permissionsAsked)
            {
                var claim = perm.AsClaim();
                if (!currentRoleClaims.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                {
                    var assignResult = await roleManager.AddClaimAsync(role, claim);
                    if(!assignResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Permission {perm.Id} assign didn't succeed");
                    }
                }
                    
            }
        }

        public async Task<IEnumerable<string>> GetAllRolesAsync()
        {
            return await roleManager.Roles.Select(r => r.Name!).ToListAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionAsync()
        {
            return await securityRepository.GetAllPermissions().ToListAsync();
        }
    }
}

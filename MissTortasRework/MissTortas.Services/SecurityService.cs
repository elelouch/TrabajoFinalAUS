using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;
using MissTortas.Services.Security.Constants;
using System.Security.Claims;

namespace MissTortas.Services
{
    public class SecurityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenGenerator tokenGenerator
        ) : ISecurityService
    {
        public async Task<LoginUserResultDTO> SignInUserAsync(LoginUserDTO request)
        {
            var user = await userManager.FindByNameAsync(request.Username) ?? throw new UserNotFoundException($"User {request.Username} not found.");
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
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task AssignClaimsAsync(long roleId, IEnumerable<Claim> claims)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString()) ?? throw new RoleNotFound("Role not found.");
            var areClaimsValid = claims.All(
                inputClaim => ClaimConstants.AllClaims.Any(
                    availableClaim => inputClaim.Type == availableClaim.Type && inputClaim.ValueType == availableClaim.ValueType
                )
            );
            var currentRoleClaims = await roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                if (!currentRoleClaims.Any(crc => crc.Type == claim.Type && crc.ValueType == claim.ValueType))
                {
                    await roleManager.AddClaimAsync(role, claim);
                }
                
            }
        }

        public List<Claim> GetAllAvailableClaims()
        {
            return ClaimConstants.AllClaims;
        }
    }
}

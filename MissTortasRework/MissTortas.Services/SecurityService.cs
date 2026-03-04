using Azure.Core;
using Microsoft.AspNetCore.Identity;
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
        public async Task<LoginUserResultDTO> LoginUser(LoginUserDTO request)
        {
            var user = await userManager.FindByNameAsync(request.Email);
            if (user is null)
            {
                return NotFound("User not found. Checkout credentials.");
            }
            var result = await signInManager.PasswordSignInAsync(user, request.Password, true, true);
            if (result.IsLockedOut)
                return Unauthorized("User locked out. Contact the system administrator.");
            if (result.IsNotAllowed)
                return Unauthorized("Wrong credentials.");
            if (result.Succeeded)
            {
                var dtoRet = new UserLogin
                {
                    Id = user.Id,
                    Username = user.UserName!,
                    AccessToken = tokenGenerator.GenerateToken(user)
                };
                return dtoRet;
            }
            return Unauthorized("Something went wrong, try again.");
        }

        public async Task<SignUpUserResultDTO> SignUpUser(SignUpUserDTO request)
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
            var newUserDTO = new SignUpUserResultDTO();
            
            var userCreation = await userManager.CreateAsync(newUser, request.Password);
            if (!userCreation.Succeeded)
            {
                newUserDTO.IdentityResult = userCreation;
                newUserDTO.Errors = userCreation.Errors;
                return newUserDTO;
            }
            var newRoleName = $"{newUser.Id}-{newUser.UserName}";
            var trivialRole = new ApplicationRole { Trivial = true, Name = newRoleName };
            var roleCreation = await roleManager.CreateAsync(trivialRole);
            if (!roleCreation.Succeeded)
            {
                newUserDTO.IdentityResult = roleCreation;
                newUserDTO.Errors = roleCreation.Errors;
                return newUserDTO;
            }
            var trivialRoleAssign = await userManager.AddToRoleAsync(newUser, newRoleName);
            if (!trivialRoleAssign.Succeeded)
            {
                newUserDTO.IdentityResult = trivialRoleAssign;
                newUserDTO.Errors = trivialRoleAssign.Errors;
                return newUserDTO;
            }
            await userManager.AddToRoleAsync(newUser, ApplicationRole.UserRole.Name!);

            return newUserDTO;
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

        }
    }
}

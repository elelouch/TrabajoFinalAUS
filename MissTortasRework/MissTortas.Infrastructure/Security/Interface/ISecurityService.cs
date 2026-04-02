using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
using System.Security.Claims;

namespace MissTortas.Infrastructure.Security.Interface
{
    public interface ISecurityService
    {
        public Task<RoleDTO> GetRoleAsync(long id);
        public Task<IEnumerable<Claim>> GetUserClaimsAsync(long userId);
        public IEnumerable<Permission> GetAllPermissions();
        public Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        public Task<IEnumerable<ApplicationUser>> GetUsersForAsync(CurrentUserDTO user);
        public Task<LoginUserResultDTO?> SignInUserAsync(LoginUserDTO dto);
        public Task<SignUpUserResultDTO> SignUpUserAsync(SignUpUserDTO dto);
        public Task<IEnumerable<SimpleRoleDTO>> GetAllRolesAsync();
        public Task AssignPermissionsToRoleAsync(AssignPermissionsToRoleDTO dto);
        public Task AssignPermissionsToUserAsync(AssignPermissionsToRoleDTO dto);
        public Task AssignPermissionsAsync(AssignPermissionsDTO dto);
        public Task ModifyUserAsync(UserModificationDTO dto);
    }
}
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security.DTO;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;

namespace MissTortas.Infrastructure.Security.Interface
{
    public interface ISecurityService
    {
        public Task<SimpleRoleDTO> CreateRoleAsync(string name);
        public Task<List<SimpleRoleDTO>> CreateRolesAsync(List<string> names);
        public Task<RoleDTO?> GetRoleByNameAsync(string name);
        public Task<RoleDTO?> FindRoleByIdAsync(string roleId);
        public IEnumerable<Permission> GetAllPermissions();
        public Task<UserFullDTO?> GetUserByIdAsync(string userId);
        public Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        public Task<LoginUserResultDTO?> SignInUserAsync(LoginUserDTO dto);
        public Task<SignUpUserResultDTO> SignUpUserAsync(SignUpUserDTO dto);
        public Task<IEnumerable<SimpleRoleDTO>> GetAllRolesAsync();
        public Task ModifyRoleAsync(ModifyRoleDTO dto);
        public Task AssignPermissionsAsync(AssignPermissionToUserDTO dto);
        public Task AssignPermissionsAsync(AssignPermissionsDTO dto);
        public Task ModifyUserAsync(ApplicationUserModificationDTO dto);
        Task<RefreshTokenResultDTO?> RefreshTokenAsync(string refreshToken);
        Task<Dictionary<long, string>> UserDomainIdToUsernameAsync(IEnumerable<long> userIds);
    }
}
using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Services.RoleService
{
    public interface IRoleService
    {
        public Task<Role?> GetRoleAsync(string roleId);
        public Task<List<Role>> GetRolesAsync();
        public Task<Role> CreateRoleAsync(string name);
        public Task ModifyRoleAsync(Role role);
    }
}

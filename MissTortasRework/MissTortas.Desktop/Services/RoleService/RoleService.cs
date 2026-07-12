using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.Shared;

namespace MissTortas.Desktop.Services.RoleService
{
    public class RoleService(MissTortasHttpClient httpClient) : IRoleService
    {
        public async Task<Role> CreateRoleAsync(string name)
        {
            var role = new Role() { Name = name };
            var newRole = await httpClient.PostAsync<Role>("roles", role);
            return newRole!;
        }

        public async Task<Role?> GetRoleAsync(string roleId)
        {
            var role = await httpClient.GetAsync<Role>($"roles/{roleId}");
            return role;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var roles = await httpClient.GetAsync<List<Role>>("roles");
            return roles ?? [];
        }

        public async Task ModifyRoleAsync(Role role)
        {
            if (string.IsNullOrEmpty(role.Id))
            {
                throw new InvalidOperationException("Role Id must not be empty.");
            }
            await httpClient.PutAsync<object>($"roles/{role.Id}", role);

        }
    }
}
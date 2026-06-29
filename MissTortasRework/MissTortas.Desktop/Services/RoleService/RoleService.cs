using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.RoleService
{
    public class RoleService(MissTortasHttpClient httpClient) : IRoleService
    {
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
    }
}
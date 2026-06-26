using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text;

namespace MissTortas.Desktop.Services.UserService
{
    public class UserService : IUserService
    {
        public async Task<User?> FindUserByIdAsync(string userId)
        {
            var client = MissTortasHttpClient.Instance.Client;
            var res = await client.GetAsync($"users/{userId}");
            if(res.IsSuccessStatusCode)
            {
                var ret = await res.Content.ReadFromJsonAsync<User>();
                return ret;
            }
            return null;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var client = MissTortasHttpClient.Instance.Client;
            var res = await client.GetAsync("users");
            var content = await res.Content.ReadFromJsonAsync<SimpleUser[]>();
            var ret = content?.Select(u =>
            {
                return new User
                {
                    UserId = Guid.Parse(u.Id),
                    Username = u.Username,
                    Email = u.Email,
                    Roles = u.Roles,
                    Enabled = u.Enabled
                };
            }).ToList() ?? [];
            return ret;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var client = MissTortasHttpClient.Instance.Client;
            var res = await client.GetAsync("roles");
            if (res.IsSuccessStatusCode)
            {
                var ret = await res.Content.ReadFromJsonAsync<Role[]>();
                return ret?.ToList() ?? [];
            }
            return [];
        }
    }
}

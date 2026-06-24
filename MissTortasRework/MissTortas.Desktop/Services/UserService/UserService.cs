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
                return await res.Content.ReadFromJsonAsync<User>();
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

        public User MapRowToUser(DataGridViewRow row)
        {
            return new User
            {
                UserId = row.Cells["UserId"].Value is Guid guid ? guid : Guid.Empty,
                FirstName = (string)(row.Cells["FirstName"].Value ?? string.Empty),
                LastName = (string)(row.Cells["LastName"].Value ?? string.Empty),
                Username = (string)(row.Cells["Username"].Value ?? string.Empty),
                Email = (string)(row.Cells["Email"].Value ?? string.Empty),
                Roles = ((string)(row.Cells["Roles"].Value ?? string.Empty))
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries),
                Enabled = row.Cells["Enabled"].Value is bool enabled ? enabled : false,
                Permissions = ((string)(row.Cells["Permissions"].Value ?? string.Empty))
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            };
        }
    }
}

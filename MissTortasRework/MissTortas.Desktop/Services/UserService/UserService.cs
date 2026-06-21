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
        public async Task<List<User>> GetAllUsersAsync()
        {
            var client = MissTortasHttpClient.Instance.Client;
            var res = await client.GetAsync("users");
            var content = await res.Content.ReadFromJsonAsync<SimpleUser[]>();
            var ret = content?.Select(u =>
            {
                return new User
                {
                    Guid = Guid.Parse(u.Id),
                    Username = u.Username,
                    Email = u.Email,
                    Roles = u.Roles,
                    IsEnabled = u.Enabled
                };
            }).ToList() ?? [];
            return ret;
        }
    }
}

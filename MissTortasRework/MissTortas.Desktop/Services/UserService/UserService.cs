using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.Shared;

namespace MissTortas.Desktop.Services.UserService
{
    public class UserService(IMissTortasHttpClient httpClient) : IUserService
    {
        public async Task<User?> FindUserByIdAsync(string userId)
        {
            var res = await httpClient.GetAsync<User>($"users/{userId}");
            return res;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var res = await httpClient.GetAsync<SimpleUser[]>("users");
            var ret = res?.Select(u =>
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
            var res = await httpClient.GetAsync<Role[]>("roles");
            var ret = res?.ToList() ?? [];
            return ret;
        }

        public Task ModifyUserAsync(string userId, UserModificationDTO dto)
        {
            return httpClient.PutAsync<object>($"users/{userId}", dto);
        }
    }
}

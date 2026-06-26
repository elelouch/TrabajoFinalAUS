using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User?> FindUserByIdAsync(string userId);
        public Task<List<Role>> GetRolesAsync();
    }
}

using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User?> FindUserByIdAsync(string userId);
        public Task<List<Role>> GetRolesAsync();
        public Task ModifyUserAsync(string userId, UserModificationDTO dto);
    }
}

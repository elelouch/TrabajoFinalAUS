using MissTortas.Domain.Security.Users;

namespace MissTortas.Services.Repositories
{
    public interface IUserRepository : IRepositoryCrud<User>
    {
        public Task<User?> FindByIdAsync(long userId);
        public Task<List<Role>> GetRolesByNameAsync(ICollection<string> roles);
        public Task<Role> CreateRoleAsync(string name);
        public Task<Role?> FindRoleByIdAsync(long roleId);
    }
}

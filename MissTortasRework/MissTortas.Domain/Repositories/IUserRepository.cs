using MissTortas.Domain.Security.Users;

namespace MissTortas.Domain.Repositories
{
    public interface IUserRepository : IRepositoryCrud<User>
    {
        public Task<User?> FindByIdAsync(long userId);
    }
}

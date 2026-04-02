using MissTortas.Domain.Security.Users;

namespace MissTortas.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> FindByIdAsync(long id);
    }
}

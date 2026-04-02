using MissTortas.Domain.Security.Users;

namespace MissTortas.Repository
{
    public interface IUserRepository
    {
        public Task<User?> FindByIdAsync(long id);
    }
}

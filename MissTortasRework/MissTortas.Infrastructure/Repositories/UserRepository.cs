using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Repositories;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.Context;

namespace MissTortas.Infrastructure.Repositories
{
    public class UserRepository(MissTortasContext context) : RepositoryCrud<User>(context), IUserRepository
    {
        public DbSet<User> userSet = context.DomainUsers;
        public Task<User?> FindByIdAsync(long userId)
        {
            return userSet.Include(u => u.Roles).Where(u => u.Id == userId).SingleOrDefaultAsync();
        }
    }
}

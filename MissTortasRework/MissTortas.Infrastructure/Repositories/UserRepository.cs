using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.Context;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Repositories
{
    public class UserRepository(MissTortasContext context) : RepositoryCrud<User>(context), IUserRepository
    {
        public DbSet<User> userSet = context.DomainUsers;
        public DbSet<Role> roleSet = context.DomainRoles;
        public Task<User?> FindByIdAsync(long userId)
        {
            return userSet.Include(u => u.Roles).Where(u => u.UserId == userId).SingleOrDefaultAsync();
        }

        public Task<List<Role>> GetRolesByNameAsync(ICollection<string> roles)
        {
            return roleSet.Where(r => roles.Contains(r.Name)).ToListAsync();
        }
    }
}

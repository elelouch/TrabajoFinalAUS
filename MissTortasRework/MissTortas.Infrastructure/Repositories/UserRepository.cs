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

        public async Task<Role> CreateRoleAsync(string name)
        {
            var role = new Role { Name = name };
            await roleSet.AddAsync(role);
            await context.SaveChangesAsync();
            return role;
        }

        public Task<User?> FindByIdAsync(long userId)
        {
            return userSet.Include(u => u.Roles).Where(u => u.UserId == userId).SingleOrDefaultAsync();
        }

        public Task<Role?> FindRoleByIdAsync(long roleId)
        {
            return roleSet.Where(r => r.RoleId == roleId).SingleOrDefaultAsync();
        }

        public Task<List<Role>> GetRolesByNameAsync(ICollection<string> roles)
        {
            return roleSet.Where(r => roles.Contains(r.Name)).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Repositories
{
    public abstract class RepositoryCrud<TEntity>(DbContext dbContext) : IRepositoryCrud<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet = dbContext.Set<TEntity>();
        public DbContext Context { get; } = dbContext;

        public virtual async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task<TEntity?> FindAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            var rowsAffected = await Context.SaveChangesAsync();
            return rowsAffected;
        }

        public Task<List<TEntity>> GetAllAsync() => dbSet.ToListAsync();
    }
}

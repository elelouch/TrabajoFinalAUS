using Microsoft.EntityFrameworkCore;
using MissTortas.Repository;

namespace MissTortas.Infrastructure.Repositories
{
    public abstract class RepositoryCrud<TEntity>(DbContext dbContext) : IRepositoryCrud<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
        public DbContext Context { get; } = dbContext;

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<TEntity?> FindAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            var rowsAffected = await Context.SaveChangesAsync();
            return rowsAffected;
        }

        public IAsyncEnumerable<TEntity> GetAll() => _dbSet.AsAsyncEnumerable();
    }
}

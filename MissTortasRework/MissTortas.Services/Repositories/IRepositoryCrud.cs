namespace MissTortas.Services.Repositories
{
    public interface IRepositoryCrud<TEntity> where TEntity : class
    {
        public Task InsertAsync(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task<TEntity?> FindAsync(long id);
        public Task<List<TEntity>> GetAllAsync();
        public Task<int> SaveChangesAsync();
    }
}

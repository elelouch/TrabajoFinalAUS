using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Data.Interfaces
{
    public interface IRepositoryCrud<TEntity> where TEntity: class
    {
        public Task InsertAsync(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task<TEntity?> FindAsync(long id);
        public Task<int> SaveChangesAsync();
        public Task<List<TEntity>> FindAllAsync();
    }
}

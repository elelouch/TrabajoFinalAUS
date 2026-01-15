using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Models.Interfaces
{
    public interface IRepositoryCrud<TEntity> where TEntity: class
    {
        public Task InsertAsync(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task<TEntity?> FindAsync(long id);
        public Task<int> SaveChangesAsync();
    }
}

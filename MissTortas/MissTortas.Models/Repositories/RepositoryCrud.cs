using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissTortas.Models.Repositories
{
    public abstract class RepositoryCrud<TEntity> where TEntity: class
    {
        private readonly DbSet<TEntity> _dbSet;
    }
}

using MissTortas.Data.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> FindAllAsync();
    }
}

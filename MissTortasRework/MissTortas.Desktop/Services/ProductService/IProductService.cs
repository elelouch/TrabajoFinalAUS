using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductCategory>> GetCategories();
    }
}

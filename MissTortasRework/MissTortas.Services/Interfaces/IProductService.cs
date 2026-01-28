using MissTortas.Data.Entity.Products;
using MissTortas.Services.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> AllAsync();
        public Task<IEnumerable<Product>> AllWithDetailAsync();
        public Task<Product> CreateProductAsync(ProductCreateDTO dto);
        public Task<Product?> FindProductByNameAsync(string name);
        public Task<SaleProduct> CreateSaleProductAsync(SaleProductCreateDTO dto);
    }
}

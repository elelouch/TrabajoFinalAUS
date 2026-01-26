using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Products;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class ProductRepository(MissTortasContext context) : RepositoryCrud<Product>(context), IProductRepository
    {
        public async Task<Product?> FindProductByNameAsync(string name)
        {
            return (await context.Products.Where(p => p.Name == name).FirstOrDefaultAsync());
        }

        public async Task InsertProductDetailAsync(ProductDetail productDetail)
        {
            await context.ProductDetails.AddAsync(productDetail);
        }

        public async Task InsertSaleProductAsync(SaleProduct saleProduct)
        {
            await context.SaleProducts.AddAsync(saleProduct);
        }
    }
}

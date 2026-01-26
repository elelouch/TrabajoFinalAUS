using MissTortas.Data.Entity.Products;

namespace MissTortas.Data.Interfaces
{
    public interface IProductRepository: IRepositoryCrud<Product>
    {
        public Task InsertProductDetailAsync(ProductDetail productDetail);
        public Task InsertSaleProductAsync(SaleProduct saleProduct);
        public Task<Product?> FindProductByNameAsync(string name);
    }
}

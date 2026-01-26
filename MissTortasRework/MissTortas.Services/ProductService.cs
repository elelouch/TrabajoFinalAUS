using MissTortas.Data.Entity.Products;
using MissTortas.Data.Interfaces;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<Product?> FindProductByNameAsync(string name)
        {
            return await productRepository.FindProductByNameAsync(name);
        }

        public async Task<Product> CreateProductAsync(ProductCreateDTO dto)
        {
            var productDetail = new ProductDetail { Description = dto.Description };
            await productRepository.InsertProductDetailAsync(productDetail);
            await productRepository.SaveChangesAsync();
            var result = await productRepository.FindProductByNameAsync(dto.Name);
            if (result is not null)
            {
                throw new AlreadyCreatedException("Product with that name already created");
            }
            var product = new Product { Name = dto.Name, ProductDetail = productDetail };
            await productRepository.InsertAsync(product);
            await productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return (await productRepository.FindAllAsync());
        }

        public async Task<SaleProduct> CreateSaleProductAsync(SaleProductCreateDTO dto)
        {
            var product = (await productRepository.FindAsync(dto.ProductId)) ?? throw new EntityNotFoundException("No stock product related found"); ;
            var saleProduct = new SaleProduct
            {
                StockProduct = product,
                SalePrice = dto.SalePrice,
                SaleQuantity = dto.SaleQuantity,
                SaleDescription = dto.SaleDescription
            };
            await productRepository.InsertSaleProductAsync(saleProduct);
            await productRepository.SaveChangesAsync();
            return saleProduct;
        }

    }
}

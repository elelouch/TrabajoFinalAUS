using Microsoft.AspNetCore.Razor.TagHelpers;
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
        public async Task<Product?> GetProductByNameAsync(string name) =>
            await productRepository.GetProductByNameAsync(name);

        public async Task<Product> CreateProductAsync(ProductCreateDTO dto)
        {
            var productDetail = new ProductDetail { Description = dto.Description };
            await productRepository.InsertProductDetailAsync(productDetail);
            await productRepository.SaveChangesAsync();
            var result = await productRepository.GetProductByNameAsync(dto.Name);
            if (result is not null)
            {
                throw new AlreadyCreatedException("Product with that name already created");
            }
            var productCategory = await productRepository.GetProductCategoryAsync(dto.CategoryId) ?? throw new EntityNotFoundException("Category not found");
            if (!productCategory.IsFinal)
            {
                throw new ChildAppendException("Cannot append a product on a category that is not final");
            }
            var product = new Product { Name = dto.Name, ProductDetail = productDetail, ProductCategory = productCategory };
            await productRepository.InsertAsync(product);
            await productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> AllAsync() => await productRepository.GetAllAsync();
        public async Task<IEnumerable<Product>> AllWithDetailAsync() => await productRepository.GetAllWithDetailAsync();

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
        public async Task<ProductCategory> CreateProductCategoryAsync(ProductCategoryCreateDTO dto)
        {
            var parent = await productRepository.GetProductCategoryAsync(dto.ParentId);
            if (parent is not null && parent.IsFinal)
            {
                throw new ParentIsFinalException("Parent is final, cannot append another category");
            }
            var productCategory = new ProductCategory
            {
                Name = dto.Name,
                Parent = parent,
                Children = [],
                Products = [],
                IsFinal = dto.IsFinal
            };
            await productRepository.InsertProductCategoryAsync(productCategory);
            await productRepository.SaveChangesAsync();
            return productCategory;
        }

        public async Task<IEnumerable<ProductCategory>> AllProductCategoriesAsync() =>
            await productRepository.GetAllProductCategoriesAsync();

        public async Task<IEnumerable<ProductCategory>> AllProductCategoriesWithParentAsync() =>
            await productRepository.GetAllProductCategoriesWithParentAsync();

        public async Task DeleteProductCategory(long id)
        {
            var pc = await productRepository.GetProductCategory(id) ?? throw new ProductCategoryNotFound("Product category not found");
            await productRepository.DeleteProductCategory(pc);
        }
    }
}

using MissTortas.Domain.Products;
using MissTortas.Services.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Context
{
    public static class ProductMappingExtensions
    {
        public static IQueryable<ProductDADto> ToProductDADto(this IQueryable<Product> query)
        {
            return query.Select(p => new ProductDADto
            {
                Id = p.ProductId,
                CategoryId = p.ProductCategoryId,
                Description = p.ProductDetail.Description,
                Name = p.Name,
                Unit = p.Unit,
                Quantity = p.Quantity,
                ManageQuantityAsInteger = p.ManageQuantityAsInteger,
                Enabled = p.Enabled
            });
        }
        public static IQueryable<SaleProductDADto> ToSaleProductDADto(this IQueryable<SaleProduct> query)
        {
            return query.Select(sp => new SaleProductDADto
            {
                Id = sp.SaleProductId,
                StockProductId = sp.ProductId,
                Name = sp.Product.Name,
                Description = sp.Product.ProductDetail.Description,
                ManageQuantityAsInteger = sp.Product.ManageQuantityAsInteger,
                SaleQuantity = sp.SaleQuantity,
                StockQuantity = sp.Product.Quantity,
                SalePrice = sp.SalePrice,
                Unit = sp.Product.Unit,
                Enabled = sp.Product.Enabled,
                IsAvailable = sp.IsAvailable,
                CategoryId = sp.Product.ProductCategoryId
            });
        }
    }
}

using MissTortas.Data.Entity.Products;
using MissTortas.Services.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Mapper
{
    public class ProductMapper : IProductMapper
    {
        public ProductCategoryDTO ProductCategoryToDTO(ProductCategory product)
        {
            return new ProductCategoryDTO
            {
                ParentId = product.Parent?.Id ?? 0,
                IsFinal = product.IsFinal,
                Name = product.Name,
                Children = [.. product.Children.Select(child => ChildrenProductCategoryToDTO(child))]
            };
        }

        public IEnumerable<ProductCategoryDTO> ProductCategoryToDTO(IEnumerable<ProductCategory> products)
        {
            return products.Select(pc => ProductCategoryToDTO(pc));
        }

        public IEnumerable<ProductDTO> ProductToDTO(IEnumerable<Product> products)
        {
            return products.Select(p => ProductToDTO(p));
        }

        public ProductDTO ProductToDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.ProductDetail?.Description ?? string.Empty,
                CategoryId = product.ProductCategory?.Id ?? 0
            };
        }

        public SaleProductDTO SaleProductToDTO(SaleProduct product)
        {
            return new SaleProductDTO
            {
                Id = product.Id,
                Price = product.SalePrice,
                Description = product.SaleDescription,
                Quantity = product.SaleQuantity
            };
        }

        public ChildrenProductCategoryDTO ChildrenProductCategoryToDTO(ProductCategory pc)
        {
            return new ChildrenProductCategoryDTO
            {
                Id = pc.Id,
                Name = pc.Name
            };
        }

        public IEnumerable<ChildrenProductCategoryDTO> ChildrenProductCategoryToDTO(IEnumerable<ProductCategory> pc)
        {
            throw new NotImplementedException();
        }
    }
}

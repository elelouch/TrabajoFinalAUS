using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Mapping.Interfaces;

namespace MissTortas.Services.Mapping
{
    public class ProductMapper : IProductMapper
    {
        public CategoryDTO ProductCategoryToDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                ParentId = category.Parent?.Id ?? 0,
                IsFinal = category.IsFinal,
                Name = category.Name,
                Children = [.. category.Children.Select(child => ProductCategoryToDTO(child))]
            };
        }

        public IEnumerable<CategoryDTO> ProductCategoryToDTO(IEnumerable<ProductCategory> products)
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
                Price = product.SalePrice
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

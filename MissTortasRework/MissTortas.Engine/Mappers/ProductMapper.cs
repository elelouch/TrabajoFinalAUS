using MissTortas.Data.Entity.Products;
using MissTortas.Services.DTO.Products;

namespace MissTortas.Engine.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public ProductCategoryDTO ProductCategoryToDTO(ProductCategory pc)
        {
            return new ProductCategoryDTO
            {
                Id = pc.Id,
                Name = pc.Name,
                ParentId = pc.Parent is null ? 0 : pc.Parent.Id
            };
        }
        public List<ProductCategoryDTO> ProductCategoryToDTO(IEnumerable<ProductCategory> cats)
        {
            return [.. cats.Select(c => ProductCategoryToDTO(c))];
        }
    }
}

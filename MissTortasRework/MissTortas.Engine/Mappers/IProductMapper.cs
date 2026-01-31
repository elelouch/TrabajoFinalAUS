using MissTortas.Data.Entity.Products;
using MissTortas.Engine.DTO.Products;

namespace MissTortas.Engine.Mappers
{
    public interface IProductMapper
    {
        public ProductCategoryDTO ProductCategory(ProductCategory pc);
        public List<ProductCategoryDTO> ProductCategory(IEnumerable<ProductCategory> cats);
    }
}

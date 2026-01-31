using MissTortas.Services.DTO.Products;

namespace MissTortas.Engine.Mappers
{
    public interface IProductMapper
    {
        public ProductCategoryDTO ProductCategoryToDTO(ProductCategory pc);
        public List<ProductCategoryDTO> ProductCategoryToDTO(IEnumerable<ProductCategory> cats);
        public ProductDTO ProductToDTO(IEnumerable<ProductDTO> wdetail, IEnumerable<ProductCategory> cats);
    }
}

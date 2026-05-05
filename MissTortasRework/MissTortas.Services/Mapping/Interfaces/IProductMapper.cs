using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;

namespace MissTortas.Services.Mapping.Interfaces
{
    public interface IProductMapper
    {
        public IEnumerable<ProductDTO> ProductToDTO(IEnumerable<Product> products);
        public ProductDTO ProductToDTO(Product product);
        public SaleProductDTO SaleProductToDTO(SaleProduct product);
        public IEnumerable<SaleProductDTO> SaleProductToDTO(IEnumerable<SaleProduct> products);
        public CategoryDTO CategoryToDTO(Category product);
        public IEnumerable<CategoryDTO> CategoryToDTO(IEnumerable<Category> product);
        public ChildrenProductCategoryDTO ChildrenProductCategoryToDTO(ProductCategory pc);
        public IEnumerable<ChildrenProductCategoryDTO> ChildrenProductCategoryToDTO(IEnumerable<ProductCategory> pc);
    }
}

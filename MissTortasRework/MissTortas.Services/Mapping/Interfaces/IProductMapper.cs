using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;

namespace MissTortas.Services.Mapping.Interfaces
{
    public interface IProductMapper
    {
        public IEnumerable<ProductDTO> ProductToDTO(IEnumerable<Product> products);
        public ProductDTO ProductToDTO(Product product);
        public SaleProductDTO SaleProductToDTO(SaleProduct product);
        public ProductCategoryDTO ProductCategoryToDTO(ProductCategory product);
        public IEnumerable<ProductCategoryDTO> ProductCategoryToDTO(IEnumerable<ProductCategory> product);
        public ChildrenProductCategoryDTO ChildrenProductCategoryToDTO(ProductCategory pc);
        public IEnumerable<ChildrenProductCategoryDTO> ChildrenProductCategoryToDTO(IEnumerable<ProductCategory> pc);
    }
}

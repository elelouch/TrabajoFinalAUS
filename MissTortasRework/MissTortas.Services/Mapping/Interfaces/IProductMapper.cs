using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Repositories.DTO;

namespace MissTortas.Services.Mapping.Interfaces
{
    public interface IProductMapper
    {
        public IEnumerable<ProductDTO> ProductToDTO(IEnumerable<ProductDADto> products);
        public IEnumerable<ProductDTO> ProductToDTO(IEnumerable<Product> products);
        public ProductDTO ProductToDTO(Product product);
        public ProductDTO ProductToDTO(ProductDADto product);
        public SaleProductDTO SaleProductToDTO(SaleProduct product);
        public IEnumerable<SaleProductDTO> SaleProductToDTO(IEnumerable<SaleProduct> products);
        public IEnumerable<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> product, bool onlyEnabled);
        public ProductCategoryDTO CategoryToDTO(ProductCategory product);
        public IEnumerable<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> product);
        public ChildrenProductCategoryDTO ChildrenProductCategoryToDTO(ProductCategory pc);
        public IEnumerable<ChildrenProductCategoryDTO> ChildrenProductCategoryToDTO(IEnumerable<ProductCategory> pc);
    }
}

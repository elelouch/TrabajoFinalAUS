using MissTortas.Data.Entity.Products;
using MissTortas.Services.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Mapper
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

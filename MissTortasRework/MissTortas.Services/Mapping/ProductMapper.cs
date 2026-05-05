using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Mapping.Interfaces;

namespace MissTortas.Services.Mapping
{
    public class ProductMapper : IProductMapper
    {
        public CategoryDTO CategoryToDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.ResourceId,
                ParentId = category.ParentId,
                IsFinal = category.IsFinal,
                Name = category.Name,
                Children = []
            };
        }

        public IEnumerable<CategoryDTO> CategoryToDTO(IEnumerable<Category> categories)
        {
            var dtoLookup = new Dictionary<long, CategoryDTO>(categories.Count());

            foreach (var cat in categories)
            {
                dtoLookup[cat.ResourceId] = CategoryToDTO(cat);
            }

            var roots = new List<CategoryDTO>();

            foreach (var c in categories)
            {
                var dto = dtoLookup[c.ResourceId];

                if (c.ParentId == 0)
                {
                    roots.Add(dto);
                }
                else
                {
                    if (dtoLookup.TryGetValue(c.ParentId, out var parent))
                    {
                        parent.Children.Add(dto);
                    }
                    else
                    {
                        roots.Add(dto);
                    }
                }
            }
            return roots;
        }

        public IEnumerable<ProductDTO> ProductToDTO(IEnumerable<Product> products)
        {
            return products.Select(p => ProductToDTO(p));
        }

        public ProductDTO ProductToDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.ResourceId,
                Name = product.Name,
                Description = product.ProductDetail?.Description ?? string.Empty,
                CategoryId = product.ProductCategory?.ResourceId ?? 0
            };
        }

        public SaleProductDTO SaleProductToDTO(SaleProduct product)
        {
            return new SaleProductDTO
            {
                Id = product.ResourceId,
                Price = product.SalePrice
            };
        }

        public ChildrenProductCategoryDTO ChildrenProductCategoryToDTO(ProductCategory pc)
        {
            return new ChildrenProductCategoryDTO
            {
                Id = pc.ResourceId,
                Name = pc.Name
            };
        }

        public IEnumerable<ChildrenProductCategoryDTO> ChildrenProductCategoryToDTO(IEnumerable<ProductCategory> pc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleProductDTO> SaleProductToDTO(IEnumerable<SaleProduct> products)
        {
            return products.Select(prod => SaleProductToDTO(prod));
        }
    }
}

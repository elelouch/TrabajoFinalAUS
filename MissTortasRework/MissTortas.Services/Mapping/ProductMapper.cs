using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Mapping.Interfaces;

namespace MissTortas.Services.Mapping
{
    public class ProductMapper : IProductMapper
    {
        public ProductCategoryDTO CategoryToDTO(ProductCategory category)
        {
            return new ProductCategoryDTO
            {
                ProductCategoryId = category.ProductCategoryId,
                ParentId = category.ParentId,
                IsFinal = category.IsFinal,
                Name = category.Name,                
                Children = []
            };
        }

        public IEnumerable<ProductCategoryDTO> CategoryToDTO(IEnumerable<ProductCategory> categories)
        {
            var dtoLookup = new Dictionary<long, ProductCategoryDTO>(categories.Count());

            foreach (var cat in categories)
            {
                dtoLookup[cat.ProductCategoryId] = CategoryToDTO(cat);
            }

            var roots = new List<ProductCategoryDTO>();

            foreach (var c in categories)
            {
                var dto = dtoLookup[c.ProductCategoryId];

                if (c.ParentId == 0)
                {
                    roots.Add(dto);
                }
                else
                {
                    if (dtoLookup.TryGetValue(c.ParentId ?? 0, out var parent))
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
                Id = product.ProductId,
                Name = product.Name,
                Description = product.ProductDetail?.Description ?? string.Empty,
                CategoryId = product.ProductCategoryId
            };
        }

        public SaleProductDTO SaleProductToDTO(SaleProduct product)
        {
            return new SaleProductDTO
            {
                Id = product.SaleProductId,
                Name = product.Product.Name,
                Price = product.SalePrice,
                Quantity = product.SaleQuantity,
                AllowDecimalAsk = product.Product.ManageQuantityAsInteger,
                StockProductId = product.ProductId
            };
        }

        public ChildrenProductCategoryDTO ChildrenProductCategoryToDTO(ProductCategory pc)
        {
            return new ChildrenProductCategoryDTO
            {
                Id = pc.ProductCategoryId,
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

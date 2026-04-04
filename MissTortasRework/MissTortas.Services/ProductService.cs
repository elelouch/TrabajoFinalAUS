using MissTortas.Domain.Products;
using MissTortas.Domain.Repositories;
using MissTortas.Domain.Security.Authorization;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapping.Interfaces;

namespace MissTortas.Services
{
    public class ProductService(
        IProductRepository productRepository,
        IProductMapper productMapper,
        IRightsService rightsService
        ) : IProductService
    {
        public async Task<ProductDTO?> GetProductByNameAsync(string name)
        {
            var product = await productRepository.FindProductByNameAsync(name);
            if (product is not null)
            {
                return productMapper.ProductToDTO(product);
            }
            return null;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductCreateDTO dto)
        {
            var productDetail = new ProductDetail { Description = dto.Description };
            await productRepository.InsertProductDetailAsync(productDetail);
            await productRepository.SaveChangesAsync();
            var result = await productRepository.FindProductByNameAsync(dto.Name);
            if (result is not null)
            {
                throw new AlreadyCreatedException("Product with that name already created");
            }
            var productCategory = await productRepository.FindProductCategoryAsync(dto.CategoryId) ?? throw new EntityNotFoundException("Category not found");
            if (!productCategory.IsFinal)
            {
                throw new ChildAppendException("Cannot append a product on a Category that is not final");
            }

            var product = new Product
            {
                Name = dto.Name,
                ProductDetail = productDetail,
                ProductCategory = productCategory,
                ManageQuantityAsInteger = dto.ManageQuantityAsInteger
            };
            await productRepository.InsertAsync(product);
            await productRepository.SaveChangesAsync();
            return productMapper.ProductToDTO(product);
        }

        public async Task<IEnumerable<ProductDTO>> AllAsync()
        {
            var products = productRepository.GetAll();
            var productList = await products.ToListAsync();
            return productMapper.ProductToDTO(productList);
        }
        public async Task<IEnumerable<ProductDTO>> AllWithDetailAsync()
        {
            var products = productRepository.GetAllWithDetail();
            var productList = await products.ToListAsync();
            return productMapper.ProductToDTO(productList);
        }

        public async Task<SaleProductDTO> CreateSaleProductAsync(SaleProductCreateDTO dto)
        {
            var productCategory = await productRepository.FindProductCategoryAsync(dto.CategoryId) ?? throw new EntityNotFoundException("Category not found");
            var productDetail = new ProductDetail { Description = dto.SaleDescription, ImagePath = dto.SaleImagePath };
            await productRepository.InsertProductDetailAsync(productDetail);
            await productRepository.SaveChangesAsync();
            var saleProduct = new SaleProduct
            {
                ProductDetail = productDetail,
                ProductCategory = productCategory,
                SalePrice = dto.SalePrice,
                IsAvailable = dto.IsAvailable,
                Quantity = dto.Quantity,
            };
            await productRepository.InsertSaleProductAsync(saleProduct);
            await productRepository.SaveChangesAsync();
            return productMapper.SaleProductToDTO(saleProduct);
        }

        public async Task<CategoryDTO> CreateProductCategoryAsync(ProductCategoryCreateDTO dto)
        {
            var parent = await productRepository.FindProductCategoryAsync(dto.ParentId);
            if (parent is not null && parent.IsFinal)
            {
                throw new ParentIsFinalException("Parent is final, cannot append another category");
            }

            var productCategory = new ProductCategory
            {
                Name = dto.Name,
                Parent = parent,
                Children = [],
                Products = [],
                IsFinal = dto.IsFinal
            };

            await productRepository.InsertProductCategoryAsync(productCategory);
            if (parent is not null)
            {
                var resourceId = productCategory.Id;
                var rightsDTO = parent.Rights
                    .Select(r => new RightDTO { ResourceId = resourceId, AccessType = (int)r.AccessType, SubjectId = r.SubjectId })
                    .Where(r => r.Transferable);
                var newViewers = dto.ViewerSubjectsIds.Select(id => new Right { Transferable = true, SubjectId = id, ResourceId = resourceId, AccessType = AccessType.Read });
                await rightsService.GiveAccessBulkAsync(rightsDTO);
            }
            await productRepository.SaveChangesAsync();
            return productMapper.ProductCategoryToDTO(productCategory);
        }

        public async Task<IEnumerable<CategoryDTO>> AllCategoriesAsync()
        {
            var categories = productRepository.GetAllProductCategories();
            var categoriesList = await categories.ToListAsync();
            return productMapper.ProductCategoryToDTO(categoriesList);
        }

        public async Task DeleteProductCategory(long id)
        {
            var pc = await productRepository.GetProductCategory(id) ?? throw new ProductCategoryNotFoundException("Product category not found");
            await productRepository.DeleteProductCategory(pc);
            await productRepository.SaveChangesAsync();
        }

        public async Task<ProductDTO?> FindProduct(long id)
        {
            var product = await productRepository.FindAsync(id);
            if (product is null)
            {
                return null;
            }
            return productMapper.ProductToDTO(product);
        }

        public async Task<SaleProduct> GetSaleProductEntityAsync(long id)
        {
            var sp = await productRepository.FindSaleProductAsync(id) ?? throw new SaleProductNotFoundException("Product for sale not found");
            return sp;
        }

        public async Task<ProductDTO> UpdateProductAsync(UpdateProductDTO dto)
        {
            var product = await productRepository.GetWithDetailAsync(dto.ProductId);
            var category = await productRepository.FindProductCategoryAsync(dto.CategoryId);
            product.ProductDetail.Description = dto.Description;
            var qty = ValidateQuantity(dto.Quantity, product.ManageQuantityAsInteger);
            product.Quantity = qty.DecimalQuantity;
            if (category is not null)
            {
                product.ProductCategory = category;
            }
            productRepository.Update(product);
            await productRepository.SaveChangesAsync();
            return productMapper.ProductToDTO(product);
        }

        private static QuantityHolder ValidateQuantity(double qty, bool mustBeInteger)
        {
            var qtyIsInteger = Math.Floor(qty) == qty;
            if (mustBeInteger && !qtyIsInteger)
            {
                throw new AskQuantityException("Quantity is not valid, try an integer quantity.");
            }
            var intQty = (long)Math.Floor(qty);
            if (mustBeInteger && intQty < 0 && intQty > (long.MaxValue - 1024))
            {
                throw new AskQuantityException("The quantity is negative. It is not valid.");
            }
            return new QuantityHolder { DecimalQuantity = qty };
        }

        public async Task<List<CategoryDTO>> AllCategoriesForUserAsync(long userId)
        {
            var categories = await rightsService.GetAvailableResourceForUser<ProductCategory>(AccessType.Read, userId);
            var dtoLookup = new Dictionary<long, CategoryDTO>(categories.Count());

            foreach (var cat in categories)
            {
                dtoLookup[cat.Id] = new CategoryDTO
                {
                    Id = cat.Id,
                    Name = cat.Name,
                    IsFinal = cat.IsFinal
                };
            }

            var roots = new List<CategoryDTO>();

            foreach (var c in categories)
            {
                var dto = dtoLookup[c.Id];

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
    }
}

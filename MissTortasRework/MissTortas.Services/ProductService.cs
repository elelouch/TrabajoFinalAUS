using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Users;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapping.Interfaces;
using MissTortas.Services.Repositories;

namespace MissTortas.Services
{
    public class ProductService(
        IProductRepository productRepository,
        IProductMapper productMapper
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

        private async Task<Product> CreateProductEntityAsync(ProductCreateDTO dto)
        {
            var productDetail = new ProductDetail { Description = dto.Description, ImagePath = dto.ImagePath };
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
            return product;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductCreateDTO dto)
        {
            var product =  await CreateProductEntityAsync(dto);
            return productMapper.ProductToDTO(product);
        }

        public async Task<IEnumerable<ProductDTO>> AllAsync()
        {
            var products = await productRepository.GetAllAsync();
            return productMapper.ProductToDTO(products);
        }

        public async Task<IEnumerable<ProductDTO>> AllWithDetailAsync()
        {
            var products = await productRepository.GetAllWithDetailAsync();
            return productMapper.ProductToDTO(products);
        }

        public async Task<SaleProductDTO> CreateSaleProductAsync(SaleProductCreateDTO dto)
        {
            var productCreateDTO = new ProductCreateDTO
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                Description = dto.SaleDescription,
                ImagePath = dto.SaleImagePath,
                ManageQuantityAsInteger = true // sale products are offered by units.
            };
            var stockProduct = await CreateProductEntityAsync(productCreateDTO);
            var saleProduct = new SaleProduct
            {
                SalePrice = dto.SalePrice,
                IsAvailable = dto.IsAvailable,
                ProductId = stockProduct.ProductId
            };
            await productRepository.InsertSaleProductAsync(saleProduct);
            await productRepository.SaveChangesAsync();
            return productMapper.SaleProductToDTO(saleProduct);
        }

        public async Task<ProductCategoryDTO> CreateProductCategoryAsync(ProductCategoryCreateDTO dto)
        {
            ProductCategory? parent = null;
            if (dto.ParentId is not null)
            {
                var parentId = dto.ParentId.Value;
                parent = await productRepository.FindProductCategoryAsync(parentId); 
            }
            if (parent is not null && parent.IsFinal)
            {
                throw new ParentIsFinalException("Parent is final, cannot append another category");
            }

            var productCategory = new ProductCategory
            {
                Name = dto.Name,
                ParentId = parent?.ProductCategoryId,
                Children = [],
                Products = [],
                IsFinal = dto.IsFinal
            };

            await productRepository.InsertProductCategoryAsync(productCategory);
            await productRepository.SaveChangesAsync();
            await productRepository.SaveChangesAsync();
            return productMapper.CategoryToDTO(productCategory);
        }

        public async Task DeleteProductCategory(long id)
        {
            var pc = await productRepository.GetProductCategoryAsync(id) ?? throw new ProductCategoryNotFoundException("Product category not found");
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


        public async Task<IEnumerable<SaleProductDTO>> GetSaleProductsFromCategoryAsync(long categoryId)
        {
            var saleProducts = await productRepository.GetSaleProductsFromCategoryAsync(categoryId);
            return productMapper.SaleProductToDTO(saleProducts);
        }

        public async Task<IEnumerable<ProductCategoryDTO>> AllProductCategoryAsync()
        {
            var cats = await productRepository.GetAllProductCategoriesAsync();
            return productMapper.CategoryToDTO(cats);
        }
    }
}

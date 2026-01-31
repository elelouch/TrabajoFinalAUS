using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Data.Entity.Products;
using MissTortas.Services.DTO.Products;
using System.Collections.Generic;

namespace MissTortas.Engine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController(
            IProductService productService,
            IValidator<CreateProductDTO> createProductValidator,
            IValidator<CreateSaleProductDTO> createSaleProductValidator,
            IProductMapper productMapper
        )
    {
        [HttpDelete("category/{id}")]
        public async Task DeleteProductCategory(long id)
        {
            await productService.DeleteProductCategory(id);
        }

        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> GetAllProductCategory()
        {
            var categoriesWithParent = await productService.AllProductCategoriesWithParentAsync();
            return productMapper.ProductCategoryToDTO(categoriesWithParent);
        }

        [HttpPost("category")]
        public async Task<ActionResult<ProductCategoryDTO>> PostProductCategory(CreateProductCategoryDTO dto)
        {
            var productCategoryDto = new ProductCategoryCreateDTO()
            {
                Name = dto.Name,
                ParentId = dto.ParentId,
                IsFinal = dto.IsFinal
            };
            var pc = await productService.CreateProductCategoryAsync(productCategoryDto);
            return productMapper.ProductCategoryToDTO(pc);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var wdetail = await productService.AllWithDetailAsync();
            return productMapper.ProductToDTO(wdetail, ["detail"]);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(CreateProductDTO dto)
        {
            await createProductValidator.ValidateAndThrowAsync(dto);
            var productDto = new ProductCreateDTO
            {
                Name = dto.Name,
                Description = dto.Description
            };
            var p = await productService.CreateProductAsync(productDto);
            return new ProductDTO { Id = p.Id, Name = p.Name };
        }

        [HttpPost("sale")]
        public async Task<ActionResult<SaleProductDTO>> PostSaleProduct(CreateSaleProductDTO dto)
        {
            await createSaleProductValidator.ValidateAndThrowAsync(dto);
            var saleProductDto = new SaleProductCreateDTO
            {
                SalePrice = dto.SalePrice,
                SaleDescription = dto.SaleDescription,
                SaleQuantity = dto.SaleQuantity,
                ProductId = dto.ProductId
            };
            var saleProduct = await productService.CreateSaleProductAsync(saleProductDto);
            return new SaleProductDTO
            {
                Id = saleProduct.Id,
                Price = saleProduct.SalePrice,
                Quantity = saleProduct.SaleQuantity
            };
        }
        //       [HttpGet("sale")]
        //       public async Task<ActionResult<SaleProductDTO>>
    }
}

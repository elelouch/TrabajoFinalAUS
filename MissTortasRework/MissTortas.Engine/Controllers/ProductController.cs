using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Data.Entity.Products;
using MissTortas.Engine.DTO.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;
using System.Collections.Generic;

namespace MissTortas.Engine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController(
            IProductService productService,
            IValidator<CreateProductDTO> createProductValidator,
            IValidator<CreateSaleProductDTO> createSaleProductValidator
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
            var ps = await productService.AllProductCategoriesAsync();
            return ps.ToList();
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
            return pc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var ps = await productService.AllWithDetailAsync();
            return ps.ToList();
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
            return p;
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
            return saleProduct;
        }
    }
}

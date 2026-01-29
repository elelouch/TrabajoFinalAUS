using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Data.Entity.Products;
using MissTortas.Engine.DTO.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using System.Collections.Generic;

namespace MissTortas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService, IValidator<CreateProductDTO> createProductValidator, IValidator<CreateSaleProductDTO> createSaleProductValidator)
    {
        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> GetAllProductCategory(CreateProductCategoryDTO dto)
        {
           
            var productCategoryDto = new ProductCategoryCreateDTO()
            {
                Name = dto.Name,
                ParentId = dto.ParentId,
                IsFinal = dto.IsFinal
            };
            var productCategory = await productService.CreateProductCategoryAsync(productCategoryDto);
            return new ProductCategoryDTO { Id = productCategory.Id, Name = productCategory.Name };
        }

        [HttpPost("category")]
        public async Task<ActionResult<ProductCategoryDTO>> PostProductCategory (CreateProductCategoryDTO dto)
        {
            var productCategoryDto = new ProductCategoryCreateDTO()
            {
                Name = dto.Name,
                ParentId = dto.ParentId,
                IsFinal = dto.IsFinal
            };
            var productCategory = await productService.CreateProductCategoryAsync(productCategoryDto);
            return new ProductCategoryDTO { Id = productCategory.Id, Name = productCategory.Name };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts(bool details)
        {
            if(details)
            {
                var wdetail = await productService.AllWithDetailAsync();
                var retDetail = wdetail.Select(p => new ProductDTO 
                { 
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.ProductDetail.Description 
                }).ToList();
                return retDetail;
            }
            var allProducts = await productService.AllAsync();
            var ret = allProducts.Select(p => new ProductDTO { Id = p.Id, Name = p.Name }).ToList();
            return ret;
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
    }
}

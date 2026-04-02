using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Domain.Entity.Products;
using MissTortas.Presentation.DTO.Products;
using MissTortas.Presentation.Validators.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;
using System.Collections.Generic;

using UpdateProduct = MissTortas.Presentation.DTO.Products.UpdateProduct;
using UpdateProductServiceDTO = MissTortas.Services.DTO.Products.UpdateProductDTO;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController(
            IProductService productService,
            IProductsDTOValidator validators    
        ): Controller
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
        public async Task<ActionResult<ProductCategoryDTO>> PostProductCategory(CreateProductCategory dto)
        {
            await validators.ProductCategoryValidator().ValidateAndThrowAsync(dto);
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

        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductDTO>> PutProduct(long productId, UpdateProduct dto)
        {
            await validators.UpdateProductValidator().ValidateAndThrowAsync(dto);
            var productDto = new UpdateProductServiceDTO
            {
                ProductId = productId,
                CategoryId = dto.CategoryId,
                Quantity = dto.Quantity,
                Description = dto.Description
            };
            var product = await productService.UpdateProductAsync(productDto);
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(CreateProduct dto)
        {
            await validators.ProductValidator().ValidateAndThrowAsync(dto);
            var productDto = new ProductCreateDTO
            {
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                ManageQuantityAsInteger = dto.ManageQuantityAsInteger
            };
            var p = await productService.CreateProductAsync(productDto);
            return p;
        }

        [HttpPost("sale")]
        public async Task<ActionResult<SaleProductDTO>> PostSaleProduct(CreateSaleProduct dto)
        {
            await validators.SaleProductValidator().ValidateAndThrowAsync(dto);
            var saleProductDto = new SaleProductCreateDTO
            {
                SalePrice = dto.SalePrice,
                SaleDescription = dto.SaleDescription,
                Quantity = dto.SaleQuantity,
                ProductId = dto.StockProductId,
            };
            var saleProduct = await productService.CreateSaleProductAsync(saleProductDto);
            return saleProduct;
        }
    }
}

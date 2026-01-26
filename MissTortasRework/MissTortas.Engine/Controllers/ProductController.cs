using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Data.Entity.Products;
using MissTortas.Engine.DTO.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;

namespace MissTortas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService, IValidator<CreateProductDTO> createProductValidator, IValidator<CreateSaleProductDTO> createSaleProductValidator)
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var allProducts = await productService.FindAllAsync();
            return ProductDTO.FromEntity(allProducts);
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
            var product = await productService.CreateProductAsync(productDto);
            return ProductDTO.FromEntity(product);
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
            
            return SaleProductDTO.FromEntity(saleProduct);
        }
    }
}

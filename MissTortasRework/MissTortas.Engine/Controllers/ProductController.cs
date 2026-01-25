using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Data.Entity.Products;
using MissTortas.Engine.DTO.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;

namespace MissTortas.Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService, IValidator<CreateProductDTO> validator)
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
            await validator.ValidateAndThrowAsync(dto);
            var productDto = new ProductCreateDTO
            {
                Name = dto.Name,
                Description = dto.Description
            };
            var product = await productService.CreateProductAsync(productDto);
            return ProductDTO.FromEntity(product);
        }
    }
}

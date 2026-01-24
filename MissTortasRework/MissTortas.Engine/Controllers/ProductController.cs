using Microsoft.AspNetCore.Mvc;
using MissTortas.Data.Entity.Products;
using MissTortas.Engine.DTO.Products;
using MissTortas.Services.Interfaces;

namespace MissTortas.Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService)
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
            productService.CreateProduct()
        }
    }
}

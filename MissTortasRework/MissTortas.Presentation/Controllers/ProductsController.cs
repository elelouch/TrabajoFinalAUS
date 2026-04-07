using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Presentation.DTO.Products;
using MissTortas.Presentation.Validators.Products;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using System.Security.Claims;
using UpdateProduct = MissTortas.Presentation.DTO.Products.UpdateProduct;
using UpdateProductServiceDTO = MissTortas.Services.DTO.Products.UpdateProductDTO;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(
            IProductService productService,
            IValidator<UpdateProduct> updateProductValidator,
            IValidator<CreateProduct> createProductValidator
        ) : Controller
    {
        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var ps = await productService.AllWithDetailAsync();
            return ps.ToList();
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductDTO>> PutProduct(long productId, UpdateProduct dto)
        {
            await updateProductValidator.ValidateAndThrowAsync(dto);
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

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(CreateProduct dto)
        {
            await createProductValidator.ValidateAndThrowAsync(dto);
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


    }
}

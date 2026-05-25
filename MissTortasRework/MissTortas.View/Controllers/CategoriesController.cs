using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Products;
using System.Security.Claims;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController(IProductService productService, IValidator<CreateProductCategory> productCategoryValidator) : ControllerBase
    {

        [HttpGet("{categoryId}/saleproducts")]
        public async Task<ActionResult<IEnumerable<SaleProductDTO>>> GetSaleProductsFromCategory(long categoryId)
        {
            var ret = await productService.GetSaleProductsFromCategoryAsync(categoryId);
            return Ok(ret);
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpDelete("{id}")]
        public async Task DeleteProductCategory(long id)
        {
            await productService.DeleteProductCategory(id);
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllProductCategory()
        {
            var ps = await productService.AllAsync();
            return Ok(ps);
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> PostProductCategory(CreateProductCategory dto)
        {
            await productCategoryValidator.ValidateAndThrowAsync(dto);
            var productCategoryDto = new ProductCategoryCreateDTO()
            {
                Name = dto.Name,
                ParentId = dto.ParentId,
                IsFinal = dto.IsFinal
            };
            var pc = await productService.CreateProductCategoryAsync(productCategoryDto);
            return pc;
        }
    }
}

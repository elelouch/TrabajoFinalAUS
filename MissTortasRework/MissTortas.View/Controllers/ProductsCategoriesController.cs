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
    public class ProductsCategoriesController(UserManager<ApplicationUser> userManager, IProductService productService, IValidator<CreateProductCategory> productCategoryValidator) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpDelete("{id}")]
        public async Task DeleteProductCategory(long id)
        {
            await productService.DeleteProductCategory(id);
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllProductCategory()
        {
            var userId = this.User.FindFirstValue("sub") ?? "";
            var applicationUser = await userManager.FindByIdAsync(userId);
            var ps = await productService.AllCategoriesForUserAsync(applicationUser!.User.Id);
            return ps;
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

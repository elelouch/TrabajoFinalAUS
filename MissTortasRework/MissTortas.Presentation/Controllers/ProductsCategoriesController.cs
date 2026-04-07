using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Presentation.DTO.Products;
using MissTortas.Services;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using System.Security.Claims;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsCategoriesController(UserManager<ApplicationUser> userManager, IProductService productService, IValidator<CreateProductCategory> productCategoryValidator) : Controller
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

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
            IProductsDTOValidator validators,
            UserManager<ApplicationUser> userManager
        ) : Controller
    {
        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpDelete("category/{id}")]
        public async Task DeleteProductCategory(long id)
        {
            await productService.DeleteProductCategory(id);
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllProductCategory()
        {
            var userId = User.FindFirstValue("sub") ?? "";
            var applicationUser = await userManager.FindByIdAsync(userId);
            var ps = await productService.AllCategoriesForUserAsync(applicationUser!.User.Id);
            return ps;
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost("category")]
        public async Task<ActionResult<CategoryDTO>> PostProductCategory(CreateProductCategory dto)
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

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var ps = await productService.AllWithDetailAsync();
            return ps.ToList();
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPut]
        public async Task<ActionResult<ProductDTO>> PutProduct(UpdateProduct dto)
        {
            await validators.UpdateProductValidator().ValidateAndThrowAsync(dto);
            var productDto = new UpdateProductServiceDTO
            {
                ProductId = dto.ProductId,
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

        [Authorize(Policy = PolicyName.ManageProducts)]
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

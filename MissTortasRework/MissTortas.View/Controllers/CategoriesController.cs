using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController(
        IProductService productService,
        IValidator<CreateProductCategoryRequest> productCategoryValidator,
        ISimpleStorage simpleStorage
    ) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("{categoryId}/saleproducts")]
        public async Task<ActionResult<IEnumerable<SaleProductResponse>>> GetSaleProductsFromCategory(long categoryId)
        {
            var saleProducts = await productService.GetSaleProductsFromCategoryAsync(categoryId);
            List<SaleProductResponse> ret = [];
            foreach (var sp in saleProducts)
            {
                var saleProductFiles = await simpleStorage.GetProductFilesAsync(sp.Id);
                var spDTO = new SaleProductResponse(sp) { FilePaths = [.. saleProductFiles.Select(f => f.Path)] };
                ret.Add(spDTO);
            }
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
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> GetAllProductCategory([FromQuery] bool enabled)
        {
            var ps = await productService.AllProductCategoryAsync(enabled);
            return Ok(ps);
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost]
        public async Task<ActionResult<ProductCategoryDTO>> PostProductCategory(CreateProductCategoryRequest dto)
        {
            await productCategoryValidator.ValidateAndThrowAsync(dto);
            var productCategoryDto = new ProductCategoryCreateDTO()
            {
                Name = dto.Name,
                ParentId = dto.ParentId,
                IsFinal = dto.IsFinal
            };
            try
            {
                var pc = await productService.CreateProductCategoryAsync(productCategoryDto);
                return pc;
            } 
            catch(AlreadyCreatedException err)
            {
                return BadRequest(err.Message);
            }
            
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpGet("{categoryId}/products")]
        public async Task<ActionResult<List<ProductDTO>>> GetStockProducts(long categoryId)
        {
            var ret = await productService.GetProductsFromCategoryAsync(categoryId);
            return ret.ToList();
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateProductCategory(long categoryId, UpdateProductCategoryRequest updateRequest)
        {
            var dto = new UpdateProductCategoryDTO 
            { 
                ParentId = updateRequest.ParentId, 
                Enabled = updateRequest.Enabled,
                Name = updateRequest.Name, 
                ProductCategoryId = categoryId 
            };
            try
            {
                await productService.UpdateProductCategoryAsync(dto);
                return Ok();
            }
            catch (ProductCategoryNotFoundException)
            {
                return NotFound("Product category wasn't found.");
            }
            catch (ChildAppendException err)
            {
                return BadRequest($"Error while appending child:{err.Message}");
            }
            catch (InvalidOperationException err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

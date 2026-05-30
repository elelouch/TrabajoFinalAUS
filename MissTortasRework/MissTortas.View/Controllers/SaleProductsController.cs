using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleProductsController(
        IValidator<CreateSaleProduct> createSaleProductValidator,
        IProductService productService,
        ISimpleStorage simpleStorage
    ) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost]
        public async Task<ActionResult<SaleProductDTO>> PostSaleProduct([FromForm] CreateSaleProduct dto ,[FromForm] List<IFormFile> files)
        {
            await createSaleProductValidator.ValidateAndThrowAsync(dto);
            var saleProductDto = new SaleProductCreateDTO
            {
                Name = dto.SaleProductName,
                SalePrice = dto.SalePrice,
                SaleDescription = dto.SaleDescription,
                Quantity = dto.SaleQuantity,
                CategoryId = dto.CategoryId,
                SaleImagePath = dto.SaleImagePath,
                IsAvailable = false
            };
            var saleProduct = await productService.CreateSaleProductAsync(saleProductDto);
            await simpleStorage.SaveProductFileAsync(files, saleProduct.Id);
            return saleProduct;
        }
    }
}

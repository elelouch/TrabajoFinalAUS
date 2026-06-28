using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        IValidator<CreateSaleProductRequest> createSaleProductValidator,
        IProductService productService,
        ISimpleStorage simpleStorage
    ) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost]
        public async Task<ActionResult<SaleProductResponse>> PostSaleProduct([FromForm] CreateSaleProductRequest dto, [FromForm] List<IFormFile> files)
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
            var retFiles = await simpleStorage.SaveProductFileAsync(files, saleProduct.Id);
            var ret = new SaleProductResponse(saleProduct) { FilePaths = [.. retFiles.Select(f => f.Path)] };
            return ret;
        }

        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPut("{saleProductId}")]
        public async Task<ActionResult<SaleProductResponse>> PutSaleProduct(long saleProductId, UpdateSaleProductRequest updateSaleProductDTO)
        {
            var saleProductDto = new UpdateSaleProductDTO
            {
                SaleProductId = saleProductId,
                Name = updateSaleProductDTO.Name,
                Price = updateSaleProductDTO.Price,
                Description = updateSaleProductDTO.Description,
                Quantity = updateSaleProductDTO.QuantityAvailable,
            };
            var saleProduct = await productService.UpdateSaleProductAsync(saleProductDto);
            var ret = new SaleProductResponse(saleProduct);
            return ret;
        }
    }
}

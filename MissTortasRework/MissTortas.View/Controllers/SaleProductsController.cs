using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleProductsController(IValidator<CreateSaleProduct> createSaleProductValidator, IProductService productService) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ManageProducts)]
        [HttpPost]
        public async Task<ActionResult<SaleProductDTO>> PostSaleProduct(CreateSaleProduct dto)
        {
            await createSaleProductValidator.ValidateAndThrowAsync(dto);
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

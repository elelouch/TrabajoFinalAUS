using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Orders;



namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController(
        IAuthorizationService authorizationService,
        IValidator<CreateOrder> createOrderValidator,
        IOrderService orderService
        ) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(long id)
        {
            var authRes = await authorizationService.AuthorizeAsync(User, id, new OrderRequirement());
            if (!authRes.Succeeded)
            {
                return NotFound();
            }

            var order = await orderService.GetOrderAsync(id);
            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> CancelOrder(long id)
        {
            var authRes = await authorizationService.AuthorizeAsync(User, id, new OrderRequirement());
            if (!authRes.Succeeded)
            {
                return NotFound();
            }
            await orderService.CancelOrderAsync(id);
            return Ok();
        }

        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpPost("setup")]
        public async Task<ActionResult<OrderDTO>> PostSetupOrder(CreateOrder dto)
        {
            await createOrderValidator.ValidateAndThrowAsync(dto);
            var asks = dto.AskedProducts.Select(p => new Services.DTO.Products.AskedProductDTO
            {
                QuantityAsked = p.QuantityAsked,
                SaleProductId = p.SaleProductId
            });
            var placeOrder = new SetupOrderDTO
            {
                OrderManagerId = dto.OrderManagerId,
                OrderTypeId = dto.OrderTypeId,
                ClientId = dto.ClientId,
                AskedProduct = [.. asks],
                ConsultancyId = 0,
                Description = dto.Description
            };
            return await orderService.SetupOrderAsync(placeOrder);
        }



    }
}

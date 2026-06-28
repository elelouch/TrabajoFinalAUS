using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Orders;
using MissTortas.View.Mappers;



namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController(
        IAuthorizationService authorizationService,
        IValidator<CreateOrder> createOrderValidator,
        IOrderService orderService,
        IControllerOrderMapper orderMapper
        ) : ControllerBase
    {
        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(long id)
        {
            var authRes = await authorizationService.AuthorizeAsync(User, id, new OrderRequirement());
            if (!authRes.Succeeded)
            {
                return NotFound();
            }

            var orderDTO = await orderService.GetOrderAsync(id);
            if (orderDTO is null)
            {
                return NotFound();
            }
            return Ok(orderMapper.FromOrderDTOToResponse(orderDTO));
        }

        [Authorize(Policy = PolicyName.PlaceOrders)]
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
        public async Task<ActionResult<OrderResponse>> PostSetupOrder(CreateOrder dto)
        {
            await createOrderValidator.ValidateAndThrowAsync(dto);
            var setupOrderDTO = await orderMapper.FromCreateOrderToSetupOrder(dto);
            var newOrder = await orderService.SetupOrderAsync(setupOrderDTO);
            return orderMapper.FromOrderDTOToResponse(newOrder);
        }

    }
}

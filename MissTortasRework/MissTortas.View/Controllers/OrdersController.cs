using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Interface;
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
        IPresentationOrderMapper orderMapper,
        ISecurityService securityService
        ) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrders()
        {
            var orders = await orderService.GetAllOrdersAsync();
            var userids = orders.Select(order => order.ClientId);
            var dictionaryId = await securityService.UserDomainIdToAppIdAsync(userids);
            var ret = orderMapper.FromOrderDTOToResponse(orders, dictionaryId);
            return Ok(ret);
        }

        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(long id)
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
            var dictionaryId = await securityService.UserDomainIdToAppIdAsync([orderDTO.ClientId]);
            var ret = orderMapper.FromOrderDTOToResponse([orderDTO], dictionaryId).First();
            return Ok(ret);
        }

        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> PostSetupOrder(CreateOrder dto)
        {
            await createOrderValidator.ValidateAndThrowAsync(dto);
            var setupOrderDTO = await orderMapper.FromCreateOrderToSetupOrderAsync(dto);
            var newOrder = await orderService.SetupOrderAsync(setupOrderDTO);
            return orderMapper.FromOrderDTOToResponse(newOrder);
        }
        
        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpPatch("{orderId}")]
        public async Task<ActionResult> PatchOrder(long orderId, UpdateOrderRequest request)
        {
            var authRes = await authorizationService.AuthorizeAsync(User, orderId, new OrderRequirement());
            if (!authRes.Succeeded)
            {
                return NotFound();
            }
            if (request.Status == "end")
            {
                await orderService.EndOrderAsync(orderId);
            }
            else if(request.Status == "cancel")
            {
                await orderService.CancelOrderAsync(orderId);
            }
            return Ok();
        }
    }
}

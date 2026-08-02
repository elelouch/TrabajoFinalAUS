using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Domain.Orders;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Repositories.DTO;
using MissTortas.View.DTO.Orders;
using MissTortas.View.Mappers;
using System.Security.Claims;



namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController(
        IAuthorizationService authorizationService,
        IValidator<CreateOrderRequest> createOrderValidator,
        IOrderService orderService,
        IPresentationOrderMapper orderMapper,
        UserManager<ApplicationUser> userManager
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrders()
        {
            var authRes = await authorizationService.AuthorizeAsync(User, PolicyName.ManageOrders);
            if (authRes.Succeeded)
            {
                var allOrders = await orderService.GetAllOrdersAsync();
                var retAllOrders = await orderMapper.FromOrderDTOToResponse(allOrders);
                return Ok(retAllOrders);
            }

            var appUser = await userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            if (appUser == null)
            {
                return Unauthorized();
            }
            var userOrders = await orderService.GetOrdersByClientIdAsync(appUser.UserId);
            var retUserOrders = await orderMapper.FromOrderDTOToResponse(userOrders);
            return Ok(retUserOrders);
        }
            

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(long id)
        {
            var authRes = await authorizationService.AuthorizeAsync(User, id, new OrderRequirement(OrderOperation.Read));
            if (!authRes.Succeeded)
            {
                return NotFound();
            }

            var orderDTO = await orderService.GetOrderAsync(id);
            if (orderDTO is null)
            {
                return NotFound();
            }
            var ret = await orderMapper.FromOrderDTOToResponse(orderDTO);
            return Ok(ret);
        }

        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> PostOrder(CreateOrderRequest dto)
        {
            await createOrderValidator.ValidateAndThrowAsync(dto);
            var setupOrderDTO = await orderMapper.FromCreateOrderToSetupOrderAsync(dto);
            var newOrder = await orderService.SetupOrderAsync(setupOrderDTO);
            if (dto.AlreadyPaid)
            {
                var manageOrder = await authorizationService.AuthorizeAsync(User, PolicyName.ManageOrders);
                if (!manageOrder.Succeeded)
                {
                    return Forbid();
                }
                var placeOrderDTO = new PlaceOrderDTO { OrderId = newOrder.Id };
                await orderService.PlaceOrderAsync(placeOrderDTO);
            }
            var ret = await orderMapper.FromOrderDTOToResponse(newOrder);
            return Ok(ret);
        }

        [HttpPatch("{orderId}")]
        public async Task<ActionResult> PatchOrder(long orderId, UpdateOrderRequest request)
        {
            var manageSelfOrder = await authorizationService.AuthorizeAsync(User, orderId, new OrderRequirement(OrderOperation.Write));
            if (manageSelfOrder.Succeeded && request.Status == "cancel")
            {
                await orderService.CancelOrderAsync(orderId);
                return Ok();
            }
            var manageOrder = await authorizationService.AuthorizeAsync(User, PolicyName.ManageOrders);
            if (!manageOrder.Succeeded)
            {
                return Forbid();
            }
            if (request.Status == "end")
            {
                await orderService.EndOrderAsync(orderId);
            }
            else if (request.Status == "place")
            {
                var placeOrderDTO = new PlaceOrderDTO { OrderId = orderId };
                await orderService.PlaceOrderAsync(placeOrderDTO);
            }
            return Ok();
        }
    }
}

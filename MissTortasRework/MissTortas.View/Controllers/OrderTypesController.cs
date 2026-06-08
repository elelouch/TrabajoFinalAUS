using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using CreateOrderTypeRequest = MissTortas.View.DTO.Orders.CreateOrderTypeRequest;
using CreateOrderTypeServiceDTO = MissTortas.Services.DTO.Orders.CreateOrderTypeDTO;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderTypesController(IValidator<CreateOrderTypeRequest> createOrderTypeValidator, IOrderService orderService) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpPost("type")]
        public async Task<ActionResult<OrderTypeDTO>> PostOrderType(CreateOrderTypeRequest dto)
        {
            await createOrderTypeValidator.ValidateAndThrowAsync(dto);
            var orderTypeDTO = new CreateOrderTypeServiceDTO { Name = dto.Name };
            var orderType = await orderService.CreateOrderTypeAsync(orderTypeDTO);
            return orderType;
        }

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpGet("type")]
        public async Task<ActionResult<IEnumerable<OrderTypeDTO>>> AllOrderTypes()
        {
            var orderTypes = await orderService.AllOrderTypeAsync();
            return orderTypes.ToList();
        }
    }
}

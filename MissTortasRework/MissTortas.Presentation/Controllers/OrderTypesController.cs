using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Infrastructure.Security;
using MissTortas.Presentation.DTO.Orders;
using MissTortas.Services;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using CreateOrderType = MissTortas.Presentation.DTO.Orders.CreateOrderType;
using CreateOrderTypeServiceDTO = MissTortas.Services.DTO.Orders.CreateOrderTypeDTO;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderTypesController(IValidator<CreateOrderType> createOrderTypeValidator, IOrderService orderService) : Controller
    {
        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpPost("type")]
        public async Task<ActionResult<OrderTypeDTO>> PostOrderType(CreateOrderType dto)
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

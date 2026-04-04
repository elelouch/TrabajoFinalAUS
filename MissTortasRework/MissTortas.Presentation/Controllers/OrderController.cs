using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Presentation.DTO.Orders;
using MissTortas.Presentation.Validators.Orders;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using System.Security.Claims;
using CreateConsultancy = MissTortas.Presentation.DTO.Orders.CreateConsultancy;
using CreateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.CreateConsultancyDTO;
using CreateOrderType = MissTortas.Presentation.DTO.Orders.CreateOrderType;
using CreateOrderTypeServiceDTO = MissTortas.Services.DTO.Orders.CreateOrderTypeDTO;
using UpdateConsultancy = MissTortas.Presentation.DTO.Orders.UpdateConsultancy;
using UpdateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.UpdateConsultancyDTO;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController(
        IOrderService orderService,
        ISimpleStorage simpleStorage,
        IAuthorizationService authorizationService,
        IOrdersDTOValidator validators
        ) : Controller
    {
        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpPost("type")]
        public async Task<ActionResult<OrderTypeDTO>> PostOrderType(CreateOrderType dto)
        {
            await validators.CreateOrderTypeValidator().ValidateAndThrowAsync(dto);
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

        [HttpDelete("{id}/cancel")]
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
            await validators.CreateOrderValidator().ValidateAndThrowAsync(dto);
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

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpPut("preparation/{preparationId}/end")]
        public async Task<ActionResult> EndOrderPreparation(long preparationId)
        {
            await orderService.EndOrderPreparationAsync(preparationId);
            return new EmptyResult();
        }
        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpPost("consultancy")]
        public async Task<ActionResult<ConsultancyDTO>> PostConsultancy([FromForm] CreateConsultancy dto, [FromForm] List<IFormFile> files)
        {
            var consultancyDTO = new CreateConsultancyServiceDTO
            {
                ClientId = dto.ClientId,
                AssigneeId = dto.AssigneeId,
                Description = dto.Description,
                Title = dto.Title,
            };
            var consultancy = await orderService.CreateConsultancyAsync(consultancyDTO);
            await simpleStorage.SaveConsultancyFileAsync(files, consultancy.Id);
            return consultancy;
        }

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpPut("consultancy")]
        public async Task<ActionResult<ConsultancyDTO>> PutConsultancy(UpdateConsultancy dto)
        {
            var consultancyDTO = new UpdateConsultancyServiceDTO
            {
                BakeryNotes = dto.BakeryNotes,
                ConsultancyId = dto.Id,
                Status = dto.NewStatus
            };
            var consultancy = await orderService.UpdateConsultancyAsync(consultancyDTO);
            return consultancy;
        }

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpGet("consultancy/{id}")]
        public async Task<ActionResult<ConsultancyDTO>> GetConsultancy(long id)
        {
            return await orderService.GetConsultancyAsync(id);
        }

        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpGet("consultancy")]
        public async Task<ActionResult<IEnumerable<ConsultancyDTO>>> GetConsultancies()
        {
            ClaimsPrincipal principal = this.User;
            var id = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("The user must have the jwt sub claim");
            var idLong = Convert.ToInt64(id);
            var ret = await orderService.GetUserConsultanciesAsync(idLong);
            return ret.ToList();
        }

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpGet("user/{id}/consultancy")]
        public async Task<ActionResult<IEnumerable<ConsultancyDTO>>> GetUserConsultancies(long userId)
        {
            var ret = await orderService.GetUserConsultanciesAsync(userId);
            return ret.ToList();
        }
    }
}

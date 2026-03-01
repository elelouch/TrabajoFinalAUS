using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Presentation.DTO.Products;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using System.Collections;


using CreateOrderType = MissTortas.Presentation.DTO.Orders.CreateOrderType;
using CreateOrderTypeServiceDTO = MissTortas.Services.DTO.Orders.CreateOrderTypeDTO;
using PlaceOrderDTO = MissTortas.Presentation.DTO.Orders.PlaceOrder;
using PlaceOrderServiceDTO = MissTortas.Services.DTO.Orders.PlaceOrderDTO;
using CreateConsultancy = MissTortas.Presentation.DTO.Orders.CreateConsultancy;
using CreateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.CreateConsultancyDTO;
using UpdateConsultancy = MissTortas.Presentation.DTO.Orders.UpdateConsultancy;
using UpdateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.UpdateConsultancyDTO;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using MissTortas.Presentation.DTO.Orders;
using MissTortas.Presentation.Validators.Orders;
using Microsoft.AspNetCore.Authorization;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController(
        IOrderService orderService,
        IOrdersDTOValidator validators
        ) : Controller
    {
        [Authorize(Policy="ManageOrder")]
        [HttpPost("type")]
        public async Task<ActionResult<OrderTypeDTO>> PostOrderType(CreateOrderType dto)
        {
            await validators.CreateOrderTypeValidator().ValidateAndThrowAsync(dto);
            var orderTypeDTO = new CreateOrderTypeServiceDTO { Name = dto.Name };
            var orderType = await orderService.CreateOrderTypeAsync(orderTypeDTO);
            return orderType;
        }

        [HttpGet("type")]
        public async Task<ActionResult<IEnumerable<OrderTypeDTO>>> AllOrderTypes()
        {
            var orderTypes = await orderService.AllOrderTypeAsync();
            return orderTypes.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(long id)
        {
            var order = await orderService.GetOrderAsync(id);
            return order;
        }

        [HttpDelete("{id}/cancel")]
        public async Task<ActionResult> CancelOrder(long id)
        {
            await orderService.CancelOrderAsync(id);
            return new EmptyResult();
        }

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

        [HttpPut("preparation/{preparationId}/end")]
        public async Task<ActionResult> PatchOrderPreparation(long preparationId)
        {
            await orderService.EndOrderPreparationAsync(preparationId);
            return new EmptyResult();
        }

        [HttpPost("consultancy")]
        public async Task<ActionResult<ConsultancyDTO>> PostConsultancy ([FromForm]CreateConsultancy dto, [FromForm]List<IFormFile> files)
        {
            var consultancyDTO = new CreateConsultancyServiceDTO
            {
                ClientId = dto.ClientId,
                AssigneeId = dto.AssigneeId,
                Files = files,
                Description = dto.Description,
                Title = dto.Title,
            };
            var consultancy = await orderService.CreateConsultancyAsync(consultancyDTO);
            return consultancy;
        }

        [HttpPut("consultancy/{id}")]
        public async Task<ActionResult<ConsultancyDTO>> PutConsultancy(long id, UpdateConsultancy dto)
        {
            var consultancyDTO = new UpdateConsultancyServiceDTO
            {
                BakeryNotes = dto.BakeryNotes,
                ConsultancyId = id,
                Status = dto.NewStatus
            };
            var consultancy = await orderService.UpdateConsultancyAsync(consultancyDTO);
            return consultancy;
        }

        [HttpGet("consultancy/{id}")]
        public async Task<ActionResult<ConsultancyDTO>> GetConsultancy(long id)
        {
            return await orderService.GetConsultancyAsync(id);
        }

        [HttpGet("currentuser/consultancy")]
        public async Task<ActionResult<IEnumerable<ConsultancyDTO>>> GetConsultancies()
        {
            ClaimsPrincipal principal = this.User;
            var id = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("The user must have the jwt sub claim");
            var idLong = Convert.ToInt64(id);
            var ret = await orderService.GetUserConsultanciesAsync(idLong);
            return ret.ToList();
        }

        [HttpGet("user/{id}/consultancy")]
        public async Task<ActionResult<IEnumerable<ConsultancyDTO>>> GetConsultancies(long id)
        {
            var ret = await orderService.GetUserConsultanciesAsync(id);
            return ret.ToList();
        }
    }
}

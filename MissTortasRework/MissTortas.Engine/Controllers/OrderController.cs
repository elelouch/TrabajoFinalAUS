using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Engine.DTO.Orders;
using MissTortas.Engine.DTO.Products;
using MissTortas.Engine.Validators.Orders;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using System.Collections;


using CreateOrderTypeDTO = MissTortas.Engine.DTO.Orders.CreateOrderTypeDTO;
using CreateOrderTypeServiceDTO = MissTortas.Services.DTO.Orders.CreateOrderTypeDTO;
using PlaceOrderDTO = MissTortas.Engine.DTO.Orders.PlaceOrderDTO;
using PlaceOrderServiceDTO = MissTortas.Services.DTO.Orders.PlaceOrderDTO;
using CreateConsultancyDTO = MissTortas.Engine.DTO.Orders.CreateConsultancyDTO;
using CreateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.CreateConsultancyDTO;
using UpdateConsultancyDTO = MissTortas.Engine.DTO.Orders.UpdateConsultancyDTO;
using UpdateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.UpdateConsultancyDTO;

namespace MissTortas.Engine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController(
        IOrderService orderService,
        IOrdersDTOValidator validators
        )
    {
        [HttpPost("ordertype")]
        public async Task<ActionResult<OrderTypeDTO>> PostOrderType(CreateOrderTypeDTO dto)
        {
            await validators.CreateOrderTypeValidator().ValidateAndThrowAsync(dto);
            var orderTypeDTO = new CreateOrderTypeServiceDTO { Name = dto.Name };
            var orderType = await orderService.CreateOrderTypeAsync(orderTypeDTO);
            return orderType;
        }

        [HttpGet("ordertype")]
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

        [HttpDelete("cancel/{id}")]
        public async Task<ActionResult> CancelOrder(long id)
        {
            await orderService.CancelOrderAsync(id);
            return new EmptyResult();
        }

        [HttpPost("setup")]
        public async Task<ActionResult<OrderDTO>> PostSetupOrder(CreateOrderDTO dto)
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

        [HttpPost("place")]
        public async Task<ActionResult> PlaceOrder(PlaceOrderDTO dto)
        {
            await validators.PlaceOrderValidator().ValidateAndThrowAsync(dto);
            var placeOrder = new PlaceOrderServiceDTO { AssigneeId = dto.AssigneeId, Id = dto.OrderId };
            await orderService.PlaceOrderAsync(placeOrder);
            return new EmptyResult();
        }

        [HttpPut("preparation/end/{id}")]
        public async Task<ActionResult> PatchOrderPreparation(long id)
        {
            await orderService.EndOrderPreparationAsync(id);
            return new EmptyResult();
        }

        [HttpPost("consultancy")]
        public async Task<ActionResult<ConsultancyDTO>> PostConsultancy ([FromForm]CreateConsultancyDTO dto, [FromForm]List<IFormFile> files)
        {
            var consultancyDTO = new CreateConsultancyServiceDTO
            {
                ClientId = dto.ClientId,
                AssigneeId = dto.AssigneeId,
                Files = files,
                Description = dto.Description,
                Title = dto.Title
            };
            var consultancy = await orderService.CreateConsultancyAsync(consultancyDTO);
            return consultancy;
        }

        [HttpPut("consultancy/{id}")]
        public async Task<ActionResult<ConsultancyDTO>> PutConsultancy(long id, UpdateConsultancyDTO dto)
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

    }
}

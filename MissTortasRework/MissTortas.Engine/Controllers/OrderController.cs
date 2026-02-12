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
            var orderType = await orderService.CreateOrderType(orderTypeDTO);
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
            await orderService.CancelOrder(id);
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
            return await orderService.SetupOrder(placeOrder);
        }

        [HttpPost("place")]
        public async Task<ActionResult> PlaceOrder(PlaceOrderDTO dto)
        {
            await validators.PlaceOrderValidator().ValidateAndThrowAsync(dto);
            var placeOrder = new PlaceOrderServiceDTO { AssigneeId = dto.AssigneeId, Id = dto.OrderId };
            await orderService.PlaceOrder(placeOrder);
            return new EmptyResult();
        }

        [HttpPut("preparation/end/{id}")]
        public async Task<ActionResult> PatchOrderPreparation(long id)
        {
            await orderService.EndOrderPreparation(id);
            return new EmptyResult();
        }

        [HttpPost("consultancy")]
        public async Task<ActionResult<List<long>>> UploadFile(List<IFormFile> files)
        {
            var sizes = files.Select(f => f.Length).ToList();
            return sizes;
        }
    }
}

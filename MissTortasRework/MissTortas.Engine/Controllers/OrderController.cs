using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Engine.DTO.Orders;
using MissTortas.Engine.DTO.Products;
using MissTortas.Services.DTO.Order;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Interfaces;
using System.Collections;


using CreateOrderTypeDTO = MissTortas.Engine.DTO.Orders.CreateOrderTypeDTO;
using CreateOrderTypeServiceDTO = MissTortas.Services.DTO.Order.CreateOrderTypeDTO;

namespace MissTortas.Engine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController(
        IOrderService orderService,
        IValidator<CreateOrderDTO> createOrderValidator
        )
    {
        [HttpPost("ordertype")]
        public async Task<ActionResult<OrderTypeDTO>> PostOrderType(CreateOrderTypeDTO dto)
        {
            var orderTypeDTO = new CreateOrderTypeServiceDTO { Name = dto.Name };
            var orderType = await orderService.CreateOrderType(orderTypeDTO);
            return orderType;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderTypeDTO>>> AllOrderTypes()
        {
            var orderTypes = await orderService.AllOrderTypeAsync();
            return orderTypes.ToList();
        }
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PostOrder(CreateOrderDTO dto)
        {
            await createOrderValidator.ValidateAndThrowAsync(dto);
            var asks = dto.AskedProducts.Select(p => new Services.DTO.Products.AskedProductDTO
            {
                QuantityAsked = p.QuantityAsked,
                SaleProductId = p.SaleProductId
            });
            var placeOrder = new PlaceOrderDTO
            {
                OrderManagerId = dto.OrderManagerId,
                OrderTypeId = dto.OrderTypeId,
                ClientId = dto.ClientId,
                AskedProduct = [.. asks],
                ConsultancyId = 0,
                Description = dto.Description
            };
            return await orderService.PlaceOrder(placeOrder);
        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Engine.DTO.Orders;
using MissTortas.Services.DTO.Order;
using MissTortas.Services.Interfaces;
using System.Collections;

namespace MissTortas.Engine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService)
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderTypeDTO>>> AllOrderTypes()
        {
            var orderTypes = await orderService.AllOrderTypeAsync();
            return orderTypes.ToList();
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> PostOrder(CreateOrderDTO dto)
        {
            orderService.PlaceOrder()
        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Data.Entity.Orders;
using MissTortas.Services.Interfaces;
using System.Collections;

namespace MissTortas.Engine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService)
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderType>>> AllOrderTypes()
        {
            var orderTypes = await orderService.AllOrderTypeAsync();
            var ret = orderTypes.ToList();
            return ret;
        }

    }
}

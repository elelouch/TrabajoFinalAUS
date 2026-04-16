using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Services.Interfaces;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderPreparationsController(IOrderService orderService) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpDelete("{preparationId}")]
        public async Task<ActionResult> EndOrderPreparation(long preparationId)
        {
            await orderService.EndOrderPreparationAsync(preparationId);
            return new EmptyResult();
        }
    }
}

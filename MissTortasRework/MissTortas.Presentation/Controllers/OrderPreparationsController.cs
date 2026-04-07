using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Services;
using MissTortas.Services.Interfaces;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderPreparationsController(IOrderService orderService): Controller
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

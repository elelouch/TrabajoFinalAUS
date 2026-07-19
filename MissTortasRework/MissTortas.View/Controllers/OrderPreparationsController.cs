using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Orders;
using System.IdentityModel.Tokens.Jwt;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderPreparationsController(
        IOrderService orderService,
        IAuthorizationService authorizationService,
        UserManager<ApplicationUser> userManager
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<OrderPreparationDTO>>> GetOrderPreparations()
        {
            var appUser = await userManager.FindByIdAsync(User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value ?? "");
            if(appUser == null)
            {
                return Unauthorized();
            }
            var ret = await orderService.GetUserOrderPreparationsAsync(appUser.UserId);
            return Ok(ret);
        }

        [HttpPatch("{preparationId}")]
        public async Task<ActionResult> PatcthOrderPreparation(long preparationId, PatchOrderPreparationRequest request)
        {
            var requirement = new ManageAssignedPreparationRequirement();
            var authRes = await authorizationService.AuthorizeAsync(User, preparationId, requirement);
            if (!authRes.Succeeded)
            {
                return Unauthorized();
            }
            if(request.Status == "end")
            {
                await orderService.EndOrderPreparationAsync(preparationId);
            }
            else if (request.Status == "update")
            {
                var updateOrderPreparation = new UpdateOrderPreparationDTO
                {
                    AssigneeId = request.AssigneeId,
                    Detail = request.Detail,
                    OrderPreparationId = preparationId
                };
                await orderService.UpdateOrderPreparationAsync(updateOrderPreparation);
            }
            return new EmptyResult();
        }
    }
}

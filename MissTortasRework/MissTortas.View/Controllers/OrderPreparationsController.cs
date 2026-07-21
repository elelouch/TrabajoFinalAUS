using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Orders;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            var appUser = await userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            if (appUser == null)
            {
                return Unauthorized();
            }
            var ret = await orderService.GetUserOrderPreparationsAsync(appUser.UserId);
            return Ok(ret);
        }

        [HttpPatch("{preparationId}")]
        public async Task<ActionResult<OrderPreparationDTO>> PatchOrderPreparation(long preparationId, PatchOrderPreparationRequest request)
        {
            var requirement = new ManageAssignedPreparationRequirement();
            var authRes = await authorizationService.AuthorizeAsync(User, preparationId, requirement);
            OrderPreparationDTO? preparation;
            if (!authRes.Succeeded)
            {
                return Unauthorized();
            }
            if (request.Status == "end")
            {
                preparation = await orderService.EndOrderPreparationAsync(preparationId);
            }
            else
            {
                var newAssigneeId = await userManager.FindByIdAsync(request.AssigneeId);
                if (newAssigneeId == null)
                    return NotFound($"User {request.AssigneeId} not found");
                var updateOrderPreparation = new UpdateOrderPreparationDTO
                {
                    AssigneeId = newAssigneeId.UserId,
                    Detail = request.Detail,
                    OrderPreparationId = preparationId
                };
                preparation = await orderService.UpdateOrderPreparationAsync(updateOrderPreparation);
            }
            return Ok(preparation);
        }
    }
}

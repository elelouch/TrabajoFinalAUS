using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MissTortas.Infrastructure.Security.Handlers
{
    public class OrderHandler(IOrderRepository orderRepository, UserManager<ApplicationUser> userManager) : AuthorizationHandler<OrderRequirement, long>
    {
        protected async override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OrderRequirement requirement,
            long orderId)
        {
            var currentUserId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            var user = await userManager.FindByIdAsync(currentUserId);
            if (user is null)
                return;

            
            var userCanManageAllOrder = context.User.HasClaim(Permission.ClaimName, Permission.ManageOrders.Code);
            if (userCanManageAllOrder)
            {
                context.Succeed(requirement);
                return;
            }

            var orderOp = requirement.Operation;

            var orderBelongsToUser = await orderRepository.OrderBelongsToUserAsync(orderId, user.UserId);
            var userCanPlaceOrder = context.User.HasClaim(Permission.ClaimName, Permission.PlaceOrders.Code);
            if (orderBelongsToUser && userCanPlaceOrder)
            {
                context.Succeed(requirement);
                return;
            }

            var userHasPreparations = await orderRepository.IsOrderAssigneeAsync(user.UserId, orderId);
            if (userHasPreparations && orderOp == OrderOperation.Read)
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
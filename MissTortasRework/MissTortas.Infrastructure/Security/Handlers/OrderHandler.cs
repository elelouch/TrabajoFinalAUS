using Microsoft.AspNetCore.Authorization;
using MissTortas.Infrastructure.Repositories;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Infrastructure.Security.Requirements;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MissTortas.Infrastructure.Security.Handlers
{
    public class OrderHandler(OrderRepository orderRepository) : AuthorizationHandler<OrderRequirement, long>
    {
        protected async override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OrderRequirement requirement,
            long orderId)
        {
            var currentUserId = Int64.Parse(context.User.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? "0");
            var orderBelongsToUser = await orderRepository.BelongsToUserAsync(orderId, currentUserId);
            var userCanManageAllOrder = context.User.HasClaim(Permission.ClaimName, Permission.ManageOrders.Code);
            var userCanPlaceOrder = context.User.HasClaim(Permission.ClaimName, Permission.PlaceOrders.Code);
            if (userCanManageAllOrder || orderBelongsToUser && userCanPlaceOrder)
            {
                context.Succeed(requirement);
            }
        }
    }
}
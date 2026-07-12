using Microsoft.AspNetCore.Authorization;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Security.Handlers
{
    public class ManageAssignedPreparationHandler(IOrderService orderService) : AuthorizationHandler<ManageAssignedPreparationRequirement>
    {
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAssignedPreparationRequirement requirement)
        {
            orderService
        }
    }
}

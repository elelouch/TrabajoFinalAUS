using Microsoft.AspNetCore.Authorization;
using MissTortas.Services.Security.Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Handlers
{
    internal class ViewUserRequirementHandler : AuthorizationHandler<ViewUserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ViewUserRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}

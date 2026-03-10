using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.Security.Requirements
{
    public class UpdateUserRequirement : IAuthorizationRequirement
    {
        public long UserId { get; set; }
        public required Claim RequiredClaim { get; set; }
    }
}

using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.Security.Requirements
{
    public class ViewUserRequirement : IAuthorizationRequirement
    {
        public long UserId { get; set; }
        public required Claim RequiredClaim { get; set; }
    }
}

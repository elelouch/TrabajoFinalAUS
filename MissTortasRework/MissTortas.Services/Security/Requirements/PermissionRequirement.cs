using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Requirements
{
    public class PermissionRequirement(string claimType, string claimValue) : IAuthorizationRequirement
    {
        public string ClaimType { get; } = claimType;
        public string ClaimValue { get; } = claimValue;
    }

}

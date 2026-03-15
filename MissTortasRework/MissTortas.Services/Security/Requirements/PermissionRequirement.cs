using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.Security.Requirements
{
    public class PermissionRequirement(List<Claim> claimsRequired) : IAuthorizationRequirement
    {
        public List<Claim> ClaimsRequired { get; set; } = claimsRequired;
    }

}

using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Requirement
{
    public class ViewUserRequirement (ViewUserPermission viewUserPermission): IAuthorizationRequirement
    {
        public ViewUserPermission ViewUserPermission { get; set; } = viewUserPermission;
    }
}

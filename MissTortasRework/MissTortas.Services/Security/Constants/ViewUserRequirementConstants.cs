using MissTortas.Data.Entity.Security.User;
using MissTortas.Services.Security.Requirement;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Constants
{
    public static class ViewUserRequirementConstants
    {
        public static ViewUserRequirement ViewAllUserRequirement { get; set; } = new(ViewUserPermission.ViewAll);
    }
}

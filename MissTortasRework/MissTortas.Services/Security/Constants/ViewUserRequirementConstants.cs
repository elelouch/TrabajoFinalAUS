using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Services.Security.Requirement;

namespace MissTortas.Services.Security.Constants
{
    public static class ViewUserRequirementConstants
    {
        public static ViewUserRequirement ViewAllUserRequirement { get; set; } = new(ViewUserPermission.ViewAll);
    }
}

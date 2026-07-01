using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Infrastructure.Security.Permissions;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionsController(ISecurityService securityService) : ControllerBase
    {
        [Authorize(Policy = PolicyName.ReadPermissions)]
        [HttpGet]
        public async Task<IEnumerable<string>> GetAllPermissions()
        {
            return securityService.GetAllPermissions().Select(p => p.Code);
        }
    }
}

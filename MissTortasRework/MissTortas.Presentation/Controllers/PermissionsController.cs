using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Permissions;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionsController(SecurityService securityService) : Controller
    {
        [Authorize(Policy = PolicyName.ReadPermissions)]
        [HttpGet]
        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            return securityService.GetAllPermissions();
        }
    }
}

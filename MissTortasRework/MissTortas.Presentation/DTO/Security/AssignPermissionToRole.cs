using System.Security.Claims;

namespace MissTortas.Presentation.DTO.Security
{
    public class AssignPermissionToRole
    {
        public List<string> Permissions { get; set; } = [];
        public long RoleId { get; set; }
    }
}

using System.Security.Claims;

namespace MissTortas.Presentation.DTO.Security
{
    public class AssignPermissionToRole
    {
        public List<SimpleClaim> Claims { get; set; } = [];
        public long RoleId { get; set; }
    }
}

using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Events
{
    public class RoleCreatedArgs(Role role)
    {
        public Role Role
        {
            get
            {
                return role;
            }
        }
    }
}

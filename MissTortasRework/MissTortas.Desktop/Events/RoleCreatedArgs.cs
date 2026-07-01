using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

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

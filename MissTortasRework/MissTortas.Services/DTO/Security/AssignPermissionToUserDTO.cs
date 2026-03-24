using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class AssignPermissionToUserDTO
    {
        public long UserId { get; set; }
        public List<long> Permissions { get; set; } = [];
    }
}

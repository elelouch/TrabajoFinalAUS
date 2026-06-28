using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class UpdateRoleDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

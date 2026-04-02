using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class RoleDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<string> Permissions { get; set; } = [];
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class UserModificationDTO
    {   
        public long UserId { get; set; }
        public bool? IsEnabled { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<string>? Roles { get; set; }
    }
}

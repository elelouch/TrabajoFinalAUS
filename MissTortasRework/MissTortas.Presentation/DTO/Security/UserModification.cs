using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Presentation.DTO.Security
{
    public class UserModification
    {
        public bool? IsEnabled { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
    }
}

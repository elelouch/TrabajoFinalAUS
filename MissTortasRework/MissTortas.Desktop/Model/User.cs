using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Model
{
    public class User
    {
        public Guid Guid { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string[] Roles { get; set; } = [];
        public bool IsEnabled { get; set; }
        public string[] Permissions { get; set; } = [];
    }
}

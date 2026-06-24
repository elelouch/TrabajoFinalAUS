using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string[] Roles { get; set; } = [];
        public bool Enabled { get; set; }
        public string[] Permissions { get; set; } = [];
    }
}

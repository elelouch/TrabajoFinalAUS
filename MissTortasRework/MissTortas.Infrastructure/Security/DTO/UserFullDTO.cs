using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Security.DTO
{
    public class UserFullDTO
    {
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<string> Roles { get; set; } = [];
        public ICollection<string> Permissions { get; set; } = [];
        public bool Enabled { get; set; }
    }
}

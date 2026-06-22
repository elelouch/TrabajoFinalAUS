using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.AuthService
{
    public class SignupRequest
    {
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
    }
}

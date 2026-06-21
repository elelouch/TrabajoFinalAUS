using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.AuthService
{
    public class SignInDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

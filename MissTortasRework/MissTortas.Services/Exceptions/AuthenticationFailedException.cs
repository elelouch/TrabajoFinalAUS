using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    public class AuthenticationFailedException : BusinessException
    {
        public AuthenticationFailedException(string message, string? code = null)
            : base(message, code) { }
    }
}

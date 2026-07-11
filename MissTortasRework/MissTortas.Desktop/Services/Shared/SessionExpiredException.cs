using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.Shared
{
    public class SessionExpiredException : Exception
    {
        public SessionExpiredException(string message) : base(message) { }
    }

}

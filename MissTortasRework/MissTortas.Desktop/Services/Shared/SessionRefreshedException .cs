using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.Shared
{
    public class SessionRefreshedException : Exception
    {
        public SessionRefreshedException(string message) : base(message) { }
    }
}

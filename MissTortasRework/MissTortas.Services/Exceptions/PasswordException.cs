using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    public class PasswordException(string message): Exception(message)
    {
    }
}

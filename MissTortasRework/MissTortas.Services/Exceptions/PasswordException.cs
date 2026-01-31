using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.Exceptions
{
    public class PasswordException(string message): Exception(message)
    {
    }
}

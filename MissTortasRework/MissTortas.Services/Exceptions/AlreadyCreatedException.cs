using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.Exceptions
{
    internal class AlreadyCreatedException(string message): Exception(message)
    {
    }
}

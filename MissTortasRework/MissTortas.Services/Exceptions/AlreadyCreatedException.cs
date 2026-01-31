using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    internal class AlreadyCreatedException(string message): Exception(message)
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.Exceptions
{
    public class EntityNotFoundException(string message) : Exception(message)
    {
    }
}

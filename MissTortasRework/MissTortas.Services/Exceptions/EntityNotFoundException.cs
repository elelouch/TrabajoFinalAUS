using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    public class EntityNotFoundException(string message) : Exception(message)
    {
    }
}

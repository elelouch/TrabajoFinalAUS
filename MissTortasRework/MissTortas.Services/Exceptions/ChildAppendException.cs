using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.Exceptions
{
    public class ChildAppendException(string message): Exception(message)
    {
    }
}

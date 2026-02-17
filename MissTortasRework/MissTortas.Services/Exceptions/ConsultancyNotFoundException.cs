using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    public class ConsultancyNotFoundException(string message) : EntityNotFoundException(message)
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    public class SaleProductNotFoundException (string message) : EntityNotFoundException(message)
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    internal class SaleProductAlreadyVinculatedException (string message): Exception(message)
    {
    }
}

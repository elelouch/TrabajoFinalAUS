using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    internal class PaymentMethodDetailException(string message) : Exception(message)
    {
    }
}

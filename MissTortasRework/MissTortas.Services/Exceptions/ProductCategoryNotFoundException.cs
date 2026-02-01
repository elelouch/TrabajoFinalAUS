using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    public class ProductCategoryNotFoundException(string message): EntityNotFoundException(message)
    {
    }
}

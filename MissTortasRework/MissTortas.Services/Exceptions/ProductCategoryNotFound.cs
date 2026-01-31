using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.Exceptions
{
    public class ProductCategoryNotFound(string message): Exception(message)
    {
    }
}

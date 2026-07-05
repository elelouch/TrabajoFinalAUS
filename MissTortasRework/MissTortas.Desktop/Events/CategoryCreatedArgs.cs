using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Events
{
    public class CategoryCreatedArgs(ProductCategory cat)
    {
        public ProductCategory Category
        {
            get
            {
                return cat;
            }
        }
    }
}

using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Events
{
    public class StockProductModified(Product product)
    {
        public Product Product
        {
            get
            {
                return product;
            }
        }
    }
}

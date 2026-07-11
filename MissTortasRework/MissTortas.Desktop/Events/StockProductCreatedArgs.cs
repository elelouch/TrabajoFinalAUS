using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Events
{
    public class StockProductCreatedArgs(Product pc)
    {
        public Product Product 
        { 
            get
            {
                return pc;
            }
        }
    }
}

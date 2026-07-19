using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Model
{
    public class SaleProductAsked
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal QuantityAsked { get; set; }
        public decimal Price { get; set; }
    }
}
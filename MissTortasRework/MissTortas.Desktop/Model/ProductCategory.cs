using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Model
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Enable { get; set; }
        public List<Product> Products { get; set; } = [];
        public List<Product> Children { get; set; } = [];
    }
}

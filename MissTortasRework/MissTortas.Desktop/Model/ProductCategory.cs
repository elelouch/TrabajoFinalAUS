using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Model
{
    public class ProductCategory : ICloneable
    {
        public long ProductCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsFinal { get; set;}
        public bool Enabled { get; set; }
        public long? ParentId { get; set; }
        public List<Product> Products { get; set; } = [];
        public List<ProductCategory> Children { get; set; } = [];

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}

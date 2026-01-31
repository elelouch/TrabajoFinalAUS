using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.DTO.Products
{
    public class ProductCategoryCreateDTO
    {
        public long ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsFinal { get; set; }
    }
}

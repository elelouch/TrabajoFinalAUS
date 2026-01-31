using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.DTO.Products
{
    public class ProductCreateDTO
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long CategoryId { get; set; }
    }
}

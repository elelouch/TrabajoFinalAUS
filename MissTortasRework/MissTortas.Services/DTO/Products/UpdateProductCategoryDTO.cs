using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Products
{
    public class UpdateProductCategoryDTO
    {
        public long ProductCategoryId { get; set; }
        public long? ParentId { get; set; }
        public bool? Enabled { get; set; }
        public string? Name { get; set; }
    }
}

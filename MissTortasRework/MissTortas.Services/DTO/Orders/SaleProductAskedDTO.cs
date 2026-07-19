using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Orders
{
    public class SaleProductAskedDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal SaleQuantity { get; set; }
        public decimal SalePrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.DTO
{
    public class UpdateSaleProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? QuantityAvailable { get; set; }
        public decimal? Price { get; set; }
    }
}

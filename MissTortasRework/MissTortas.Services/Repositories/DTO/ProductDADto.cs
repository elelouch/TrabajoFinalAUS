using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Repositories.DTO
{
    public class ProductDADto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public bool ManageQuantityAsInteger { get; set; }
        public bool Enabled { get; set; }
    }
}

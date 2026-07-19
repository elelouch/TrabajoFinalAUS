using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Model
{
    public class Order
    {
        public long Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public long StatusId { get; set; }
        public string ClientUserId { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public List<SaleProductAsked> SaleProducts { get; set; } = [];
        public List<Preparation> Preparations { get; set; } = [];
    }
}

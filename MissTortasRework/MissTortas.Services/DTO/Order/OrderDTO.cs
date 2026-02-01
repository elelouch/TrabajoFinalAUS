using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Order
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public long StatusId { get; set; }
        public long OrderMangerId { get; set; }
        public long ClientId { get; set; }
    }
}

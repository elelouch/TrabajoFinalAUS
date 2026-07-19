using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Orders
{
    public class CreateOrderPreparationDTO
    {
        public long AssigneeId { get; set; }
        public string Detail { get; set; } = string.Empty;
        public long OrderId { get; set; } 
    }
}

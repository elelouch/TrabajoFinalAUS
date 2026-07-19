using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Orders
{
    public class UpdateOrderPreparationDTO
    {
        public long OrderPreparationId { get; set; }
        public long AssigneeId { get; set; }
        public string Detail { get; set; } = string.Empty;
    }
}

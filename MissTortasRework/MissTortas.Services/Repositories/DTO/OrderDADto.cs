using MissTortas.Domain.Orders;
using MissTortas.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Repositories.DTO
{
    public class OrderDADto
    {
        public long ClientUserId { get; set; }
        public long OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public long ConsultancyId { get; set; }
        public string ConsultancyTitle { get; set; } = string.Empty;
        public DateTime ConsultancyCreationTime { get; set; }
        public DateTime Creation { get; set; }
        public long OrderManagerId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public ICollection<SaleProductAskedDADto> SaleProductAskedDADtos { get; set; } = [];
        public ICollection<OrderPreparationDADto> PreparationDADtos { get; set; } = [];
    }
}

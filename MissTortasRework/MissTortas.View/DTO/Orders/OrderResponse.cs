using MissTortas.Services.DTO.Orders;

namespace MissTortas.View.DTO.Orders
{
    public class OrderResponse
    {
        public long Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public long StatusId { get; set; }
        public string ClientUserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<OrderPreparationResponse> Preparations { get; set; } = [];
        public required List<SaleProductAskedResponse> SaleProducts { get; set; } = [];
        public string PaymentStatus { get; set; } = string.Empty;
    }
}

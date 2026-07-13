using MissTortas.Services.DTO.Orders;

namespace MissTortas.View.DTO.Orders
{
    public class OrderResponse
    {
        public long Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public long StatusId { get; set; }
        public required IEnumerable<OrderPreparationResponse> Preparations;
    }
}

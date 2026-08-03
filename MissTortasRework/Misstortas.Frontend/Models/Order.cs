namespace Misstortas.Frontend.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public long StatusId { get; set; }
        public string ClientUserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<OrderPreparation> Preparations { get; set; } = [];
        public required List<SaleProductAsked> SaleProducts { get; set; } = [];
        public string PaymentStatus { get; set; } = string.Empty;
    }
}

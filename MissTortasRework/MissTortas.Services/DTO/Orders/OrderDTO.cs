using MissTortas.Services.DTO.Products;

namespace MissTortas.Services.DTO.Orders
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public long StatusId { get; set; }
        public long OrderMangerId { get; set; }
        public long ClientId { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime Creation { get; set; } 
        public ICollection<OrderPreparationDTO> Preparations { get; set; } = [];
        public ICollection<SaleProductAskedDTO> SaleProducts { get; set; } = [];
    }
}

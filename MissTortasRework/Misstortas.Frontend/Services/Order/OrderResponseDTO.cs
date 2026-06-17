namespace Misstortas.Frontend.Services.Order
{
    public class OrderResponseDTO
    {
        public long Id { get; set; }
        public long StatusId { get; set; }
        public string Status { get; set; } = string.Empty;
        public required IEnumerable<OrderPreparationDTO> Preparations;
    }
}

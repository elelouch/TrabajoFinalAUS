namespace MissTortas.Engine.DTO.Orders
{
    public class CreateOrderDTO
    {
        public long ClientId { get; set; }
        public long OrderManagerId { get; set; }
        public List<AskedProductDTO> AskedProducts { get; set; } = [];
        public long OrderTypeId { get; set; }
        public long ConsultancyId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

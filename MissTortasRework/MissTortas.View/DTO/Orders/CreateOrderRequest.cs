namespace MissTortas.View.DTO.Orders
{
    public class CreateOrderRequest
    {
        public string ClientGuid { get; set; } = string.Empty;
        public string OrderManagerGuid { get; set; } = string.Empty;
        public List<AskedProduct> AskedProducts { get; set; } = [];
        public long OrderTypeId { get; set; }
        public long ConsultancyId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool AlreadyPaid { get; set; }
    }
}

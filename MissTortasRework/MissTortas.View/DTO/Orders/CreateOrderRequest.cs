namespace MissTortas.View.DTO.Orders
{
    public class CreateOrder
    {
        public string ClientGuid { get; set; }
        public string OrderManagerGuid { get; set; }
        public List<AskedProduct> AskedProducts { get; set; } = [];
        public long OrderTypeId { get; set; }
        public long ConsultancyId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

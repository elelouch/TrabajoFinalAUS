namespace MissTortas.View.DTO.Orders
{
    public class CreateOrder
    {
        public long ClientId { get; set; }
        public long OrderManagerId { get; set; }
        public List<AskedProduct> AskedProducts { get; set; } = [];
        public long OrderTypeId { get; set; }
        public long ConsultancyId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

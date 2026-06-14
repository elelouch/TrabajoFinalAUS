namespace Misstortas.Frontend.Services.Products
{
    public class CreateOrderDTO
    {
        public string ClientGuid { get; set; } = string.Empty;
        public string OrderManagerGuid { get; set; } = string.Empty;
        public List<AskedProductDTO> AskedProducts { get; set; } = [];
        public long OrderTypeId { get; set; }
        public long ConsultancyId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

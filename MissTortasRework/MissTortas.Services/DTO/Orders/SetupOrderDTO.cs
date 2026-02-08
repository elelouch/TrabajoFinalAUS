using MissTortas.Services.DTO.Products;

namespace MissTortas.Services.DTO.Orders
{
    public class SetupOrderDTO
    {
        public string Description { get; set; } = string.Empty;
        public required long OrderTypeId;
        public required long OrderManagerId { get; set; }
        public required long ClientId { get; set; }
        public required long ConsultancyId { get; set; }
        public required ICollection<AskedProductDTO> AskedProduct { get; set; }
    }
}

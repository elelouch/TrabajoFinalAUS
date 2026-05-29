namespace MissTortas.Services.DTO.Products
{
    public class ProductCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public bool ManageQuantityAsInteger { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}

namespace MissTortas.Models.Product
{
    public class ProductImage
    {
        public string Name { get; set; } = string.Empty;
        public required string TruePath { get; set; }
        public required string RelativePath { get; set; }
    }
}

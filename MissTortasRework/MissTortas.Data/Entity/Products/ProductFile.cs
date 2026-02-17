namespace MissTortas.Data.Entity.Products
{
    public class ProductFile
    {
        public long Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Extension { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public required Product Product { get; set; }   
    }
}

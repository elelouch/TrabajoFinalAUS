namespace MissTortas.Data.Entity.Products
{
    public class ProductImage
    {
        public long Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}

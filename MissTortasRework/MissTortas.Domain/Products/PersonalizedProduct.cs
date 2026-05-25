namespace MissTortas.Domain.Products
{
    public class PersonalizedProduct
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ProductFile? ProductImage { get; set; }
        public float FinalPrice { get; set; }
        public long ResourceId { get; set; }
        public long Resource { get; set; } = default!;
    }
}

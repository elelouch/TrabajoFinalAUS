namespace MissTortas.Domain.Products
{
    public class PersonalizedProduct
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal FinalPrice { get; set; }
    }
}

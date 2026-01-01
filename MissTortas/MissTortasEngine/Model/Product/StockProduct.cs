namespace MissTortasEngine.Model.Product
{
    public class StockProduct : Product
    {
        public override string Name { get; set; } = string.Empty;
        public override int Id { get; set; }
        public override string Description { get; set; } = string.Empty;
        public ProductImage StockImage { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public StockProduct() { }
    }
}

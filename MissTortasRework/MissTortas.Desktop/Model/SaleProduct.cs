namespace MissTortas.Desktop.Model
{
    public class SaleProduct : Product
    {
        public long StockProductId { get; set; }
        public List<string> FilePaths { get; set; } = [];
    }
}

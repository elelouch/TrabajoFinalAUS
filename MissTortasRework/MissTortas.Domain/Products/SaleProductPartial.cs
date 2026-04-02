namespace MissTortas.Domain.Products
{
    public partial class SaleProduct
    {
        public bool AllowDecimalAsk { get => !this.StockProduct.ManageQuantityAsInteger; }
    }
}

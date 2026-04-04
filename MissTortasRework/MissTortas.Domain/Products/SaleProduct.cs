namespace MissTortas.Domain.Products
{
    public partial class SaleProduct : Product
    {
        public double SalePrice { get; set; }
        public bool IsAvailable { get; set; } // used to help whether to show up on a view or modify the view, the quantity can be 0 and the product still be available to view
    }
}

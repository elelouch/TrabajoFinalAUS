using Misstortas.Frontend.Models;

namespace Misstortas.Frontend.Services.Products
{
    public interface ISaleProductCartService
    {
        IReadOnlyCollection<SaleProductCartEntry> Items { get; }

        int DistinctProductsCount { get; }

        decimal TotalPrice { get; }

        event Action? StateChanged;

        decimal GetQuantityAsked(long productId);

        bool Contains(long productId);

        public Task SetQuantity(SaleProduct product, decimal quantityAsked);
        public Task Increase(SaleProduct product, decimal amount);
        public Task Decrease(SaleProduct product, decimal amount);
        public Task Remove(long productId);
        public Task Clear();
        public Task LoadAsync();
    }
}
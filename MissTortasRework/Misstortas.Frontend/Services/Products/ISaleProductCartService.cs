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

        void SetQuantity(
            SaleProduct product,
            decimal quantityAsked);

        void Increase(
            SaleProduct product,
            decimal amount);

        void Decrease(
            SaleProduct product,
            decimal amount);

        void Remove(long productId);

        void Clear();
    }
}
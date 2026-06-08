using Misstortas.Frontend.Models;

namespace Misstortas.Frontend.Services.Products
{
    public class SaleProductCartService : ISaleProductCartService
    {
        private readonly Dictionary<long, SaleProductCartEntry> _items = [];

        public IReadOnlyCollection<SaleProductCartEntry> Items
            => _items.Values;

        public int DistinctProductsCount
            => _items.Count;

        public decimal TotalPrice
            => _items.Values.Sum(x =>
                (decimal)x.Product.Price * x.QuantityAsked);

        public event Action? StateChanged;

        public decimal GetQuantityAsked(long productId)
        {
            return _items.TryGetValue(productId, out var entry)
                ? entry.QuantityAsked
                : 0;
        }

        public bool Contains(long productId)
        {
            return _items.ContainsKey(productId);
        }

        public void SetQuantity(
            SaleProduct product,
            decimal quantityAsked)
        {
            if (quantityAsked <= 0)
            {
                Remove(product.Id);
                return;
            }

            _items[product.Id] = new SaleProductCartEntry
            {
                Product = product,
                QuantityAsked = quantityAsked
            };

            NotifyStateChanged();
        }

        public void Increase(
            SaleProduct product,
            decimal amount)
        {
            var current = GetQuantityAsked(product.Id);

            SetQuantity(product, current + amount);
        }

        public void Decrease(
            SaleProduct product,
            decimal amount)
        {
            var current = GetQuantityAsked(product.Id);

            SetQuantity(product, current - amount);
        }

        public void Remove(long productId)
        {
            if (_items.Remove(productId))
            {
                NotifyStateChanged();
            }
        }

        public void Clear()
        {
            _items.Clear();
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}
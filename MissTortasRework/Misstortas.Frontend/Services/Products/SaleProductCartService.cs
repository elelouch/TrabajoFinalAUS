using Microsoft.JSInterop;
using Misstortas.Frontend.Models;
using System.Text.Json;

namespace Misstortas.Frontend.Services.Products
{
    public class SaleProductCartService(IJSRuntime jsRuntime) : ISaleProductCartService
    {
        private bool _loaded;

        private const string StorageKey = "sale-cart";

        private readonly Dictionary<long, SaleProductCartEntry> _items = [];

        public IReadOnlyCollection<SaleProductCartEntry> Items
            => _items.Values;

        public int DistinctProductsCount
            => _items.Count;

        public decimal TotalPrice
            => _items.Values.Sum(x =>
                (decimal)x.Product.SalePrice * x.QuantityAsked);

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

        public async Task SetQuantity(
            SaleProduct product,
            decimal quantityAsked)
        {
            if (quantityAsked <= 0)
            {
                await Remove(product.Id);
                return;
            }

            _items[product.Id] = new SaleProductCartEntry
            {
                Product = product,
                QuantityAsked = quantityAsked
            };
            await SaveToSessionStorageAsync();
            NotifyStateChanged();
        }

        public async Task Increase(
            SaleProduct product,
            decimal amount)
        {
            var current = GetQuantityAsked(product.Id);
            await SetQuantity(product, current + amount);
        }

        public async Task Decrease(
            SaleProduct product,
            decimal amount)
        {
            var current = GetQuantityAsked(product.Id);
            await SetQuantity(product, current - amount);
        }

        public async Task Remove(long productId)
        {
            if (_items.Remove(productId))
            {
                NotifyStateChanged();
                await SaveToSessionStorageAsync();
            }
        }

        public async Task Clear()
        {
            _items.Clear();

            await SaveToSessionStorageAsync();
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            StateChanged?.Invoke();
        }

        private async Task SaveToSessionStorageAsync()
        {
            var json = JsonSerializer.Serialize(_items);
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", StorageKey, json);
        }
        public async Task LoadAsync()
        {
            if (_loaded)
                return;

            var json = await jsRuntime.InvokeAsync<string>(
                "sessionStorage.getItem",
                StorageKey);

            if (!string.IsNullOrWhiteSpace(json))
            {
                var items = JsonSerializer.Deserialize<
                    Dictionary<long, SaleProductCartEntry>>(json);

                if (items != null)
                {
                    _items.Clear();

                    foreach (var item in items)
                    {
                        _items[item.Key] = item.Value;
                    }

                    NotifyStateChanged();
                }
            }

            _loaded = true;
        }
    }
}
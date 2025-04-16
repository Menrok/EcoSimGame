using Blazored.LocalStorage;
using EcoSimGame.Models.List;

namespace EcoSimGame.Services;

public class MarketService : IDisposable
{
    private readonly Dictionary<string, decimal> prices = new();
    private readonly Random random = new();
    private readonly System.Timers.Timer timer;
    private readonly ILocalStorageService localStorage;

    private const string StorageKey = "marketPrices";
    public DateTime LastPriceUpdate { get; private set; } = DateTime.Now;

    public MarketService(ILocalStorageService localStorage)
    {
        this.localStorage = localStorage;

        timer = new System.Timers.Timer(30000);
        timer.Elapsed += async (_, _) => await UpdatePricesAsync();
        timer.AutoReset = true;
        timer.Start();
    }

    public async Task InitializeAsync()
    {
        var saved = await localStorage.GetItemAsync<Dictionary<string, decimal>>(StorageKey);
        if (saved != null && saved.Any())
        {
            foreach (var kvp in saved)
                prices[kvp.Key] = kvp.Value;
        }
        else
        {
            foreach (var material in MaterialList.AllMaterials)
            {
                prices[material.Name] = material.Price;
            }
            await SavePrices();
        }
    }

    public decimal GetPrice(string materialName)
    {
        return prices.TryGetValue(materialName, out var price) ? Math.Round(price, 2) : 0;
    }

    public async Task AffectPrice(string materialName, int direction)
    {
        if (!prices.ContainsKey(materialName)) return;

        decimal delta = 0.05m * direction;
        prices[materialName] = Math.Max(1m, Math.Round(prices[materialName] + delta, 2));

        await SavePrices();
    }

    private async Task UpdatePricesAsync()
    {
        foreach (var key in prices.Keys.ToList())
        {
            var change = (decimal)(random.NextDouble() - 0.5);
            prices[key] = Math.Max(1m, Math.Round(prices[key] + change, 2));
        }

        LastPriceUpdate = DateTime.Now;
        await SavePrices();
    }

    private async Task SavePrices()
    {
        await localStorage.SetItemAsync(StorageKey, prices);
    }

    public void Dispose()
    {
        timer?.Dispose();
    }
}

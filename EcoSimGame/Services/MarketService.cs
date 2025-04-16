using EcoSimGame.Models.List;

namespace EcoSimGame.Services;

public class MarketService : IDisposable
{
    private readonly Dictionary<string, decimal> prices = new();
    private readonly Random random = new();
    private readonly System.Timers.Timer timer;

    public DateTime LastPriceUpdate { get; private set; } = DateTime.Now;

    public MarketService()
    {
        foreach (var material in MaterialList.AllMaterials)
        {
            prices[material.Name] = material.Price;
        }

        timer = new System.Timers.Timer(30000);
        timer.Elapsed += (_, _) => UpdatePrices();
        timer.AutoReset = true;
        timer.Start();
    }

    public decimal GetPrice(string materialName)
    {
        return prices.TryGetValue(materialName, out var price) ? Math.Round(price, 2) : 0;
    }

    public void AffectPrice(string materialName, int direction)
    {
        if (!prices.ContainsKey(materialName)) return;

        decimal delta = 0.05m * direction;
        prices[materialName] = Math.Max(1m, Math.Round(prices[materialName] + delta, 2));
    }

    private void UpdatePrices()
    {
        foreach (var key in prices.Keys.ToList())
        {
            var change = (decimal)(random.NextDouble() - 0.5);
            prices[key] = Math.Max(1m, Math.Round(prices[key] + change, 2));
        }

        LastPriceUpdate = DateTime.Now;
    }

    public void Dispose()
    {
        timer?.Dispose();
    }
}

using Blazored.LocalStorage;
using EcoSimGame.Models;
using EcoSimGame.Services;

namespace EcoSimGame.Services;

public class GameStateService
{
    public Player Player { get; private set; } = new();
    public EnergyStorage Energy => Player.EnergyStorage;
    public List<ProductionTask> ProductionQueue { get; } = new();
    public MarketService Market { get; }

    private readonly ILocalStorageService localStorage;
    private readonly System.Timers.Timer tickTimer;

    public event Action? OnUpdate;

    public GameStateService(ILocalStorageService localStorage, MarketService market)
    {
        this.localStorage = localStorage;
        Market = market;

        tickTimer = new System.Timers.Timer(10);
        tickTimer.Elapsed += async (_, _) => await OnTick();
        tickTimer.Start();
    }

    private async Task OnTick()
    {
        Energy.Recharge();

        if (ProductionQueue.Any())
        {
            var current = ProductionQueue[0];

            if (current.StartTime == default)
                current.StartTime = DateTime.Now;

            var elapsed = (DateTime.Now - current.StartTime).TotalSeconds;
            current.TimeRemaining = Math.Max(0, current.DurationSeconds - (int)elapsed);

            if (current.TimeRemaining <= 0)
            {
                Player.Inventory.Add(current.OutputMaterial, current.OutputQuantity);
                Player.AddExperience(GetExpFor(current.OutputMaterial));
                ProductionQueue.RemoveAt(0);
                await Save();
            }
        }

        OnUpdate?.Invoke();
    }

    public bool TryStartProduction(ProductionTask task)
    {
        if (!task.Ingredients.All(i => Player.Inventory.GetQuantity(i.Key) >= i.Value)) return false;
        if (!Energy.UseEnergy(task.EnergyCost)) return false;

        foreach (var i in task.Ingredients)
            Player.Inventory.Remove(i.Key, i.Value);

        task.StartTime = DateTime.Now;
        ProductionQueue.Add(task);
        return true;
    }

    private int GetExpFor(string material) => material switch
    {
        "Deski" or "Sztabka żelaza" or "Cegła" or "Płótno" => 1,
        "Narzędzia" or "Odzież" => 5,
        _ => 0
    };

    public async Task Load()
    {
        var stored = await localStorage.GetItemAsync<Player>("player");
        if (stored != null) Player = stored;
    }

    public async Task Save()
    {
        await localStorage.SetItemAsync("player", Player);
    }
}
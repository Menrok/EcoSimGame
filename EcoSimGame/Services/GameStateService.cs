using Blazored.LocalStorage;
using EcoSimGame.Models;
using EcoSimGame.Models.List;

namespace EcoSimGame.Services
{
    public class GameStateService
    {
        public Player Player { get; private set; } = new();
        public EnergyStorage Energy => Player.EnergyStorage;
        public List<EnergyProduction> EnergyBuildings { get; private set; } = new();

        public MarketService Market { get; }
        private readonly ILocalStorageService localStorage;
        private readonly System.Timers.Timer tickTimer;

        public event Action? OnUpdate;

        public GameStateService(ILocalStorageService localStorage, MarketService market)
        {
            this.localStorage = localStorage;
            Market = market;

            tickTimer = new System.Timers.Timer(100);
            tickTimer.Elapsed += (_, _) => Tick();
            tickTimer.Start();
        }

        private void Tick()
        {
            Energy.Recharge();
            OnUpdate?.Invoke();
        }

        public async Task Load()
        {
            var stored = await localStorage.GetItemAsync<Player>("player");
            if (stored != null)
                Player = stored;

            InitializeEnergyBuildings();
        }

        public async Task Save()
        {
            await localStorage.SetItemAsync("player", Player);
        }
        private void InitializeEnergyBuildings()
        {
            EnergyBuildings = EnergyProductionList.AllBuildings
                .Select(b => new EnergyProduction(b.Name, b.EnergyPerTick, b.Cost))
                .ToList();
        }
    }
}
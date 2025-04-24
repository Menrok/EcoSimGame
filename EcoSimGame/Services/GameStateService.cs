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
        public List<PowerPlantSlot> PowerPlantSlots => Player.PowerPlantSlots;
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
            {
                Player = stored;

                if (Player.PowerPlantSlots == null || Player.PowerPlantSlots.Count == 0)
                {
                    Player.PowerPlantSlots = Enumerable.Range(0, 5).Select(_ => new PowerPlantSlot()).ToList();
                }
            }
            else
            {
                Player = new Player
                {
                    PowerPlantSlots = Enumerable.Range(0, 5).Select(_ => new PowerPlantSlot()).ToList()
                };
            }

            InitializeEnergyBuildings();

            Player.EnergyStorage.GeneratedEnergyPerTick = Player.PowerPlantSlots
                .Where(s => s.IsOccupied && s.Building != null)
                .Sum(s => s.Building.EnergyPerTick);
        }

        public async Task Save()
        {
            await localStorage.SetItemAsync("player", Player);
            var json = System.Text.Json.JsonSerializer.Serialize(Player);
            Console.WriteLine(">>> JSON gracza:");
            Console.WriteLine(json);

        }
        private void InitializeEnergyBuildings()
        {
            EnergyBuildings = EnergyProductionList.AllBuildings
                .Select(b => new EnergyProduction(b.Name, b.EnergyPerTick, b.Cost))
                .ToList();
        }

        public void InitializePowerSlots()
        {
            if (Player.PowerPlantSlots == null || Player.PowerPlantSlots.Count == 0)
            {
                Player.PowerPlantSlots.Clear();
                for (int i = 0; i < 5; i++)
                {
                    Player.PowerPlantSlots.Add(new PowerPlantSlot());
                }
            }
        }


        public void SetPowerPlant(int slotIndex, EnergyProduction newPlant)
        {
            if (slotIndex < 0 || slotIndex >= PowerPlantSlots.Count)
                return;

            var slot = PowerPlantSlots[slotIndex];

            if (slot.IsOccupied && slot.Building != null)
            {
                Player.EnergyStorage.GeneratedEnergyPerTick -= slot.Building.EnergyPerTick;
            }

            slot.Building = newPlant;
            slot.IsOccupied = true;

            Player.EnergyStorage.GeneratedEnergyPerTick += newPlant.EnergyPerTick;
        }
    }
}
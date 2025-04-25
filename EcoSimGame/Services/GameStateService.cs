using Blazored.LocalStorage;
using EcoSimGame.Models;
using EcoSimGame.Models.Energy;
using EcoSimGame.Models.Slot;

namespace EcoSimGame.Services
{
    public class GameStateService
    {
        public Player Player { get; private set; } = new();
        public EnergyStorage Energy => Player.EnergyStorage;
        public List<EnergyProduction> EnergyBuildings { get; private set; } = new();
        public List<PowerPlantSlot> PowerPlantSlots => Player.PowerPlantSlots;
        public List<EnergyStorageSlot> EnergyStorageSlots => Player.EnergyStorageSlots;
        public List<WarehouseSlot> WarehouseSlots => Player.WarehouseSlots;
        public List<FactorySlot> FactorySlots => Player.FactorySlots;

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
            UpdateFactories();
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

                if (Player.EnergyStorageSlots == null || Player.EnergyStorageSlots.Count == 0)
                {
                    Player.EnergyStorageSlots = Enumerable.Range(0, 2).Select(_ => new EnergyStorageSlot()).ToList();
                }

                if (Player.WarehouseSlots == null || Player.WarehouseSlots.Count == 0)
                {
                    Player.WarehouseSlots = Enumerable.Range(0, 4).Select(_ => new WarehouseSlot()).ToList();
                }

                if (Player.FactorySlots == null || Player.FactorySlots.Count == 0)
                {
                    Player.FactorySlots = Enumerable.Range(0, 16).Select(_ => new FactorySlot()).ToList();
                }
            }
            else
            {
                Player = new Player
                {
                    PowerPlantSlots = Enumerable.Range(0, 5).Select(_ => new PowerPlantSlot()).ToList(),
                    EnergyStorageSlots = Enumerable.Range(0, 2).Select(_ => new EnergyStorageSlot()).ToList(),
                    WarehouseSlots = Enumerable.Range(0, 4).Select(_ => new WarehouseSlot()).ToList(),
                    FactorySlots = Enumerable.Range(0, 16).Select(_ => new FactorySlot()).ToList()
                };
            }

            InitializeEnergyBuildings();

            Player.EnergyStorage.GeneratedEnergyPerTick = Player.PowerPlantSlots
                .Where(s => s.Building != null)
                .Sum(s => s.Building!.EnergyPerTick);

            UpdateTotalEnergyStorage();
        }


        public async Task Save()
        {
            await localStorage.SetItemAsync("player", Player);
            var json = System.Text.Json.JsonSerializer.Serialize(Player);
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
                Player.PowerPlantSlots!.Clear();
                for (int i = 0; i < 5; i++)
                    Player.PowerPlantSlots.Add(new PowerPlantSlot());
            }
        }
        public void InitializeEnergyStorageSlots()
        {
            if (Player.EnergyStorageSlots == null || Player.EnergyStorageSlots.Count == 0)
            {
                Player.EnergyStorageSlots = new List<EnergyStorageSlot>();
                for (int i = 0; i < 2; i++)
                    Player.EnergyStorageSlots.Add(new EnergyStorageSlot());
            }
        }

        public void InitializeWarehouseSlots()
        {
            if (Player.WarehouseSlots == null || Player.WarehouseSlots.Count == 0)
            {
                Player.WarehouseSlots = new List<WarehouseSlot>();
                for (int i = 0; i < 4; i++)
                    Player.WarehouseSlots.Add(new WarehouseSlot());
            }
        }
        public void InitializeFactorySlots()
        {
            if (Player.FactorySlots == null || Player.FactorySlots.Count == 0)
            {
                Player.FactorySlots = new List<FactorySlot>();
                for (int i = 0; i < 16; i++)
                    Player.FactorySlots.Add(new FactorySlot());
            }
        }

        public void SetPowerPlant(int slotIndex, EnergyProduction newPlant)
        {
            if (slotIndex < 0 || slotIndex >= PowerPlantSlots.Count)
                return;

            var slot = PowerPlantSlots[slotIndex];

            if (slot.IsOccupied && slot.Building != null)
                Player.EnergyStorage.GeneratedEnergyPerTick -= slot.Building.EnergyPerTick;

            slot.Building = newPlant;
            slot.IsOccupied = true;

            Player.EnergyStorage.GeneratedEnergyPerTick += newPlant.EnergyPerTick;
            OnUpdate?.Invoke();
        }

        public void UpdateTotalEnergyStorage()
        {
            Player.EnergyStorage.MaxEnergy = Player.EnergyStorageSlots
                .Where(s => s.IsBuilt)
                .Sum(s => s.Capacity);
            OnUpdate?.Invoke();
        }

        private void UpdateFactories()
        {
            bool anyProduced = false;

            foreach (var factory in Player.FactorySlots)
            {
                if (factory.Update(Player))
                    anyProduced = true;
            }

            if (anyProduced)
                _ = Save();
        }
    }
}
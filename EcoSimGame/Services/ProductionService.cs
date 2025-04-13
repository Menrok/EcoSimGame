using EcoSimGame.Models;
using System.Timers;

namespace EcoSimGame.Services
{
    public class ProductionService
    {
        public List<ProductionTask> Queue { get; } = new();
        public ProductionTask? CurrentTask => Queue.FirstOrDefault();

        public EnergyStorage Energy => PlayerRef?.EnergyStorage ?? new EnergyStorage();

        private readonly System.Timers.Timer timer;

        public event Action? OnUpdate;
        public Player? PlayerRef { get; set; }
        public Blazored.LocalStorage.ILocalStorageService? LocalStorageRef { get; set; }

        public ProductionService()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += (_, _) => Tick();
            timer.Start();
        }

        private void Tick()
        {
            Energy.Recharge();

            if (Queue.Any())
            {
                var current = Queue[0];

                if (current.StartTime == default)
                {
                    current.StartTime = DateTime.Now;
                }

                var elapsed = (DateTime.Now - current.StartTime).TotalSeconds;
                current.TimeRemaining = Math.Max(0, current.DurationSeconds - (int)elapsed);

                if (current.TimeRemaining <= 0)
                {
                    if (PlayerRef != null)
                    {
                        PlayerRef.Inventory.Add(current.OutputMaterial, current.OutputQuantity);
                        SavePlayerState();
                    }

                    Queue.RemoveAt(0);
                }
            }

            OnUpdate?.Invoke();
        }

        public bool AddToQueue(ProductionTask task)
        {
            if (PlayerRef == null) return false;

            foreach (var kvp in task.Ingredients)
            {
                if (PlayerRef.Inventory.GetQuantity(kvp.Key) < kvp.Value)
                    return false;
            }

            if (!Energy.UseEnergy(task.EnergyCost)) return false;

            foreach (var kvp in task.Ingredients)
            {
                PlayerRef.Inventory.Remove(kvp.Key, kvp.Value);
            }

            Queue.Add(task);
            SavePlayerState();
            return true;
        }

        public void UpgradeEnergyStorage()
        {
            if (PlayerRef != null && PlayerRef.EnergyStorage.TryUpgrade(PlayerRef.Money, out decimal newMoney))
            {
                PlayerRef.Money = newMoney;
                SavePlayerState();
            }
        }

        private async void SavePlayerState()
        {
            if (PlayerRef != null && LocalStorageRef != null)
            {
                await LocalStorageRef.SetItemAsync("player", PlayerRef);
            }
        }
    }
}

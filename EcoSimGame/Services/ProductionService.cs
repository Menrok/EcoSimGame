using Blazored.LocalStorage;
using EcoSimGame.Models;

namespace EcoSimGame.Services
{
    public class ProductionService
    {
        public List<ProductionTask> Queue { get; } = new();
        public ProductionTask? CurrentTask => Queue.FirstOrDefault();
        private readonly System.Timers.Timer timer;

        public Player? PlayerRef { get; set; }
        public ILocalStorageService? LocalStorageRef { get; set; }
        public event Action? OnUpdate;

        public ProductionService()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += (_, _) => Tick();
            timer.Start();
        }

        private void Tick()
        {
            if (Queue.Any())
            {
                var current = Queue[0];

                if (current.StartTime == default)
                    current.StartTime = DateTime.Now;

                var elapsed = (DateTime.Now - current.StartTime).TotalSeconds;
                current.TimeRemaining = Math.Max(0, current.DurationSeconds - (int)elapsed);

                if (current.TimeRemaining <= 0)
                {
                    FinishTask(current);
                    Queue.RemoveAt(0);

                    if (Queue.Any())
                        Queue[0].StartTime = DateTime.Now;
                }
            }

            OnUpdate?.Invoke();
        }

        private void FinishTask(ProductionTask task)
        {
            if (PlayerRef != null)
            {
                PlayerRef.Inventory.Add(task.OutputMaterial, task.OutputQuantity);

                if (task.OutputMaterial is "Deski" or "Sztabka żelaza" or "Cegła" or "Płótno")
                    PlayerRef.AddExperience(1);
                else if (task.OutputMaterial is "Narzędzia" or "Odzież")
                    PlayerRef.AddExperience(5);

                SavePlayerState();
            }
        }

        public bool AddToQueue(ProductionTask task)
        {
            if (PlayerRef == null) return false;

            if (!task.Ingredients.All(i => PlayerRef.Inventory.GetQuantity(i.Key) >= i.Value)) return false;
            if (!PlayerRef.EnergyStorage.UseEnergy(task.EnergyCost)) return false;

            foreach (var ingredient in task.Ingredients)
                PlayerRef.Inventory.Remove(ingredient.Key, ingredient.Value);

            if (!Queue.Any())
                task.StartTime = DateTime.Now;

            Queue.Add(task);
            SavePlayerState();
            return true;
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
using EcoSimGame.Models.Energy;
using EcoSimGame.Models.Slot;

namespace EcoSimGame.Models;

public class Player
{
    public string Name { get; set; }
    public decimal Money { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    public Inventory Inventory { get; set; }
    public int WarehouseCapacity { get; set; } = 0;

    public EnergyStorage EnergyStorage { get; set; } = new();
    public List<PowerPlantSlot> PowerPlantSlots { get; set; } = new();
    public List<EnergyStorageSlot> EnergyStorageSlots { get; set; } = new();
    public List<WarehouseSlot> WarehouseSlots { get; set; } = new();
    public List<FactorySlot> FactorySlots { get; set; } = new();

    public DateTime? LastProcessingTime { get; set; }

    public Player()
    {
        Name = "Nazwa";
        Money = 10000.0m;
        Level = 1;
        Experience = 0;
        Inventory = new Inventory();
    }

    public void AddExperience(int amount)
    {
        Experience += amount;

        while (Experience >= GetExperienceForNextLevel(Level + 1))
        {
            Level++;
        }
    }

    public int GetExperienceForNextLevel(int level)
    {
        return level switch
        {
            2 => 100,
            3 => 500,
            4 => 1500,
            5 => 2500,
            _ => int.MaxValue
        };
    }

    public int GetCurrentInventorySize() => Inventory.GetAllWithQuantity().Sum(item => item.Quantity);
    public bool CanAddToWarehouse(int quantity) => GetCurrentInventorySize() + quantity <= WarehouseCapacity;

    public bool TryAddToInventory(string materialName, int quantity)
    {
        if (!CanAddToWarehouse(quantity))
            return false;

        Inventory.Add(materialName, quantity);
        return true;
    }

    public void UpdateTotalWarehouseCapacity()
    {
        WarehouseCapacity = WarehouseSlots
            .Where(w => w.IsBuilt)
            .Sum(w => w.Capacity);
    }
}
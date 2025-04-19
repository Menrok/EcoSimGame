namespace EcoSimGame.Models;

public class Player
{
    public string Name { get; set; }
    public decimal Money { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    public Inventory Inventory { get; set; }
    public int WarehouseCapacity { get; set; } = 100;
    public int WarehouseUpgradeCost { get; set; } = 200;

    public EnergyStorage EnergyStorage { get; set; } = new();

    public DateTime? LastProcessingTime { get; set; }
    public List<string> OwnedSchematics { get; set; }

    public Player()
    {
        Name = "Nazwa";
        Money = 1000.0m;
        Level = 1;
        Experience = 0;
        Inventory = new Inventory();
        OwnedSchematics = new List<string>();
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

    public bool TryBuySchematic(string schematicName, int requiredLevel, decimal cost)
    {
        if (Level >= requiredLevel && Money >= cost && !OwnedSchematics.Contains(schematicName))
        {
            Money -= cost;
            OwnedSchematics.Add(schematicName);
            return true;
        }

        return false;
    }

    public bool CanBuySchematic(string schematicName, int requiredLevel, decimal cost)
    {
        return Level >= requiredLevel && Money >= cost && !OwnedSchematics.Contains(schematicName);
    }

    public bool HasSchematic(string schematicName) => OwnedSchematics.Contains(schematicName);
    public int GetCurrentInventorySize() => Inventory.GetAllWithQuantity().Sum(item => item.Quantity);
    public bool CanAddToWarehouse(int quantity) => GetCurrentInventorySize() + quantity <= WarehouseCapacity;
    
    public bool UpgradeWarehouse()
    {
        if (Money >= WarehouseUpgradeCost)
        {
            Money -= WarehouseUpgradeCost;
            WarehouseCapacity += 50;
            WarehouseUpgradeCost += 1000;
            return true;
        }
        return false;
    }

    public bool TryAddToInventory(string materialName, int quantity)
    {
        if (!CanAddToWarehouse(quantity))
            return false;

        Inventory.Add(materialName, quantity);
        return true;
    }
}